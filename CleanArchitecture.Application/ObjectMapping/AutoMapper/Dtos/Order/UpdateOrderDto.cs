using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.ShippingAddress;


namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

public class UpdateOrderDto : BaseDto
{
    public string OrderDescription { get; set; }
    public UpdateShippingAddressDto? ShippingAddress { get; set; }

    public List<UpdateOrderItemDto> OrderItems { get; set; }
}