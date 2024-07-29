using CleanArchitecture.Application.Mediators.Abstract;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Queries
{
    public record GetOrderQuery(int OrderId) : IQuery<GetOrderResponse>;

}
