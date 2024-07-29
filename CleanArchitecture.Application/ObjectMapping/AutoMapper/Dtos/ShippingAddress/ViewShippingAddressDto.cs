using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.ShippingAddress;

public class ViewShippingAddressDto:BaseDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public string Floor { get; set; }
    public string Apartment { get; set; }
}