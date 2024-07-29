using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Tax;

public class CreateTaxDto:BaseDto
{
    public string TaxName { get; set; }
    public decimal TaxValue { get; set; }
    public decimal TaxPercent { get; set; }
    public bool IsActive { get; set; }

    public int OrderItemId { get; set; }
    public int OrderId { get; set; }

}