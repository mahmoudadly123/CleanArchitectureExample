using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands
{
    public record UpdateOrderCommand(int OrderId,
                                    int UpdatedById,
                                    UpdateOrderDto UpdatedOrderDto) : ICommand<UpdateOrderResponse>;
}
