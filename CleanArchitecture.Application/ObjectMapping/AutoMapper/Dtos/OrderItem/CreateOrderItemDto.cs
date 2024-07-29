using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Tax;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;

public class CreateOrderItemDto:BaseDto
{
    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Quantity { get; set; }

    public decimal AdditionsValue { get; set; }
    public decimal AdditionsPercent { get; set; }

    public decimal TaxesValue { get; set; }
    public decimal TaxesPercent { get; set; }


    public decimal DiscountValue { get; set; }
    public decimal DiscountPercent { get; set; }

    public List<ViewTaxDto>? ItemTaxes { get; set; }
}