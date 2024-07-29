using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Tax;

public class UpdateTaxDto:BaseDto
{
    public string TaxName { get; set; }
    public decimal TaxValue { get; set; }
    public decimal TaxPercent { get; set; }
    public bool IsActive { get; set; }
    
}