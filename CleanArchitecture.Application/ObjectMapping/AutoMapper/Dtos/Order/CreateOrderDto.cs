using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.ShippingAddress;


namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;

public class CreateOrderDto:BaseDto
{
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderDescription { get; set; }
    public CreateShippingAddressDto? ShippingAddress { get; set; }

    public List<CreateOrderItemDto> OrderItems { get; set; }
}