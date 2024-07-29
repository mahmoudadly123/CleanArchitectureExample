using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;

public class DeleteOrderItemDto:BaseDto
{
    public int Id { get; set; }
}