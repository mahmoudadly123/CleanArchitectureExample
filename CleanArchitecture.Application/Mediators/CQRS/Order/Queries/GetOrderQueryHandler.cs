using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Queries
{
    public class GetOrderQueryHandler : QueryHandler<GetOrderQuery, GetOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper) : base(mapper)
        {
            _orderRepository = orderRepository;
        }

        
        public override async Task<Result<GetOrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var orderEntity = await _orderRepository.GetAsync(request.OrderId);

                if (orderEntity is null)
                    return Result.Failure<GetOrderResponse>(OrderErrors.NotFoundOrder);

                //Convert Domain Entity to Dto using AutoMapper
                var orderDto = AutoMapper.Map<ViewOrderDto>(orderEntity);

                var response = new GetOrderResponse(orderDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetOrderResponse>(e);
            }
        }
        


    }
}
