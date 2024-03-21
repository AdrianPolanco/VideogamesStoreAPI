
using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Address: ValueObject
    {
        public Address(Country country, string city, string street, string house)
        {
            Validate(country, city, street, house);
            Country = country;
            City = city;
            Street = street;
            House = house;
        }

        public Country Country { get; private set; }
        public string City { get; private set; }    
        public string Street { get; private set; }
        public string House { get; private set; }

        private static void Validate(Country country, string city, string street, string house)
        {
            if(country is null || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(house)) throw new ArgumentNullException();
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return Country;
            yield return Street;
            yield return House;
        }
    }
}
