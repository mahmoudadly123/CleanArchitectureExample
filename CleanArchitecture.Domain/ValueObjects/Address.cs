using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.ValueObjects
{
    public class Address: ValueObject
    {
        #region Properties

        public string Country { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string Street { get; private set; }

        #endregion

        #region Constructors

        public Address()
        {
            Country = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            Street = string.Empty;
        }
        public Address(string country, string city, string region, string street)
        {
            Country = country;
            City = city;
            Region = region;
            Street = street;
        }

        #endregion

        #region Overrides

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return City;
            yield return Region;
            yield return Street;
        }

        #endregion

    }
}
