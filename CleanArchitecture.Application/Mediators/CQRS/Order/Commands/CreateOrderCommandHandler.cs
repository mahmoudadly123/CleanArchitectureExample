using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.Validation.FluentValidation.Extensions;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Order;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.OrderItem;
using CleanArchitecture.Common.Errors.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands;

public class CreateOrderCommandHandler:CommandHandler<CreateOrderCommand,CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork , IMapper mapper, INotificationPublisher notificationPublisher) : base(unitOfWork, mapper, notificationPublisher)
    {
        _orderRepository = orderRepository;
    }


    public override async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //Validate Order Dto 
            var orderValidator = await new CreateOrderDtoValidator().ValidateAsync(request.CreateOrderDto, cancellationToken);

            if (orderValidator.IsValid == false)
            {
                return Result.Failure<CreateOrderResponse>(orderValidator.Errors);
            }

            var errors = new List<Error>();
            var createOrderDto = request.CreateOrderDto;

            //Create Order Entity
            var newOrderEntity = Domain.Aggregates.Order.Create(createOrderDto.OrderNumber, createOrderDto.OrderDate, createOrderDto.OrderDescription);

            //Create ShippingAddress Entity if Exist
            if (createOrderDto.ShippingAddress != null)
            {
                var shippingAddressResult = newOrderEntity.SetShippingAddress(createOrderDto.ShippingAddress.Country,
                                                     createOrderDto.ShippingAddress.City,
                                                     createOrderDto.ShippingAddress.Region,
                                                     createOrderDto.ShippingAddress.Street,
                                                     createOrderDto.ShippingAddress.Building,
                                                     createOrderDto.ShippingAddress.Floor,
                                                     createOrderDto.ShippingAddress.Apartment);

                if (shippingAddressResult.IsFailure)
                {
                    errors.AddRange(shippingAddressResult.Errors);
                }
            }
            

            //Create Order Items Entities
            foreach (var createOrderItemDto in createOrderDto.OrderItems)
            {
                try
                {
                    //Validate Order Item Dto 
                    var orderItemValidator = await new CreateOrderItemDtoValidator().ValidateAsync(createOrderItemDto, cancellationToken);

                    if (orderItemValidator.IsValid == false)
                    {
                        errors.AddRange(orderItemValidator.ToErrors());
                        continue;
                    }

                    var newOrderItemResult = newOrderEntity.AddItem(createOrderItemDto.Description, createOrderItemDto.UnitPrice, createOrderItemDto.Quantity);

                    if (newOrderItemResult.IsFailure)
                        errors.AddRange(newOrderItemResult.Errors);
                    
                }
                catch (Exception e)
                {
                   errors.Add(new Error(e.Message));
                }
            }

            //if errors exist then return it
            if (errors.Any())
                return Result.Failure<CreateOrderResponse>(errors);
          
            //if everything is ok then save it inside database
            //Save Entity inside Database using Repository
            await _orderRepository.AddAsync(newOrderEntity);

            //Save Changes using Unit of Work Pattern
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            //Publish All Notifications to its Handlers
            await NotificationPublisher.PublishNotificationsAsync(newOrderEntity.Notifications, cancellationToken);

            //Convert Entity To Dto
            var viewOrderDto = AutoMapper.Map<ViewOrderDto>(newOrderEntity);

            var response = new CreateOrderResponse(viewOrderDto);

            return Result.Success(response);
        }
        catch (Exception e)
        {
            return Result.Failure<CreateOrderResponse>(e);
        }
    }
}