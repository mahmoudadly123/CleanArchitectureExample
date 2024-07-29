using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.ValueObjects;

/// <summary>
/// عنوان الشحن
/// </summary>
public class ShippingAddress:ValueObject
{
    #region Properties

    public string Country { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public string Street { get; private set; }
    public string Building { get; private set; }
    public string Floor { get; private set; }
    public string Apartment { get; private set; }

    #endregion

    #region Constructors

    public ShippingAddress()
    {
        Country = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        Street = string.Empty;
        Building = string.Empty;
        Floor = string.Empty;
        Apartment = string.Empty;
    }
    private ShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        Country = country;
        City = city;
        Region = region;
        Street = street;
        Building = building;
        Floor = floor;
        Apartment = apartment;
    }

    #endregion

    #region Factory Methods

    public static Result<ShippingAddress> Create(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        return Result.Success(new ShippingAddress(country, city, region, street, building, floor, apartment));
    }

    #endregion

    #region Overrides

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Country;
        yield return City;
        yield return Region;
        yield return Street;
        yield return Building;
        yield return Floor;
        yield return Apartment;

    }

    #endregion
}