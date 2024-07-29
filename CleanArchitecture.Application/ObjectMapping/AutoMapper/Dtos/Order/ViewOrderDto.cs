using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.ShippingAddress;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

public class ViewOrderDto:BaseDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderDescription { get; set; }
    public ViewShippingAddressDto ShippingAddress { get; set; }

    public List<ViewOrderItemDto> OrderItems { get; set; }
}