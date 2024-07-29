using CleanArchitecture.Application.Mediators.Abstract;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands
{
    public record DeleteOrderCommand(int OrderId) : ICommand<DeleteOrderResponse>;
}
