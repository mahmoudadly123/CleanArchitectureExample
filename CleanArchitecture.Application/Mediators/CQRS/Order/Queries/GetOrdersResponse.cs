using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Queries;

public record GetOrdersResponse(List<ViewOrderDto> ViewOrdersDto);


