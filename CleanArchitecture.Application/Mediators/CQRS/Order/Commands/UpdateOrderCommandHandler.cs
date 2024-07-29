using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Order;
using CleanArchitecture.Common.Errors.Abstract;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands
{
    public class UpdateOrderCommandHandler : CommandHandler<UpdateOrderCommand,UpdateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<Result<UpdateOrderResponse>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Order Dto 
                var orderValidator = await new UpdateOrderDtoValidator().ValidateAsync(request.UpdatedOrderDto, cancellationToken);

                if (orderValidator.IsValid == false)
                {
                    return Result.Failure<UpdateOrderResponse>(orderValidator.Errors);
                }

                var errors = new List<Error>();
                var updatedOrderDto = request.UpdatedOrderDto;

                //Get Current Order with id
                var currentOrderEntity = await _orderRepository.Get_Order_With_Items_By_Id(request.OrderId);

                if(currentOrderEntity == null) 
                    return Result.Failure<UpdateOrderResponse>(OrderErrors.NotFoundOrder);


                //Update Order info
                //==================

                var updateDescriptionResult = currentOrderEntity.ChangeDescription(updatedOrderDto.OrderDescription);

                if(updateDescriptionResult.IsFailure)
                    errors.AddRange(updateDescriptionResult.Errors);

                //Update ShippingAddress Entity if Exist
                if (updatedOrderDto.ShippingAddress != null)
                {
                    var shippingAddressResult = currentOrderEntity.SetShippingAddress(updatedOrderDto.ShippingAddress.Country,
                        updatedOrderDto.ShippingAddress.City,
                        updatedOrderDto.ShippingAddress.Region,
                        updatedOrderDto.ShippingAddress.Street,
                        updatedOrderDto.ShippingAddress.Building,
                        updatedOrderDto.ShippingAddress.Floor,
                        updatedOrderDto.ShippingAddress.Apartment);

                    if (shippingAddressResult.IsFailure)
                    {
                        errors.AddRange(shippingAddressResult.Errors);
                    }
                }

                //Convert Order Item List From Dto To Entities
                var updatedOrderItemsEntities = AutoMapper.Map<List<Domain.Entities.OrderItem>>(updatedOrderDto.OrderItems);

                //Update Order Items
                //==================

                //Delete Removed Items
                var deleteItemsResult = currentOrderEntity.Remove_Items_NotExist_Inside_List_Of_OrderItems(updatedOrderItemsEntities);
                if(deleteItemsResult.IsFailure) 
                    errors.AddRange(deleteItemsResult.Errors);
                

                //Edit Updated Items
                var updateItemsResult = currentOrderEntity.Update_Items_From_List_Of_OrderItems(updatedOrderItemsEntities);
                if (updateItemsResult.IsFailure)
                    errors.AddRange(updateItemsResult.Errors);


                //Add New Items
                var addItemsResult = currentOrderEntity.Add_Items_From_List_Of_OrderItems(updatedOrderItemsEntities);
                if (addItemsResult.IsFailure)
                    errors.AddRange(addItemsResult.Errors);

                //if errors exist then return it
                if (errors.Any())
                    return Result.Failure<UpdateOrderResponse>(errors);

                //if everything is ok then save it inside database
                //Save Entity inside Database using Repository
                await _orderRepository.UpdateAsync(currentOrderEntity);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                //Publish All Notifications to its Handlers
                await NotificationPublisher.PublishNotificationsAsync(currentOrderEntity.Notifications, cancellationToken);

                var response = new UpdateOrderResponse();

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<UpdateOrderResponse>(e);
            }
        }
    }
}
