using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Commands;

public record CreateOrderCommand(CreateOrderDto CreateOrderDto) : ICommand<CreateOrderResponse>;
