using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Queries
{
    public class GetOrdersQueryHandler : QueryHandler<GetOrdersQuery,GetOrdersResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper) : base(mapper)
        {
            _orderRepository = orderRepository;
        }

        
        public override async Task<Result<GetOrdersResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var ordersEntities = await _orderRepository.GetAllAsync();
                
                //Convert Domain Entity to Dto using AutoMapper
                var ordersDto = AutoMapper.Map<List<ViewOrderDto>>(ordersEntities);

                var response = new GetOrdersResponse(ordersDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetOrdersResponse>(e);
            }
        }
    }
}
