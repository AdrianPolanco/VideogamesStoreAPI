

using VideogamesStore.Domain.Entities;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Tests.Messages;

namespace VideogamesStore.Tests.Domain.Value_Objects
{
    public class AddressTest
    {

        [Fact]
        public void Address_ShouldBe_Created()
        {
            List<Country> countries = new List<Country>()
            {
                Country.Create(MockResponse.responses, "United States", "Americas", "USA", @"\d{5}(-\d{4})?"),
                Country.Create(MockResponse.responses, "Andorra", "Europe", "AND", @"AD\d{3}"),
                Country.Create((dynamic)MockResponse.responses, "Brazil", "Americas", "BRA", @"\d{5}-\d{3}"),
                Country.Create((dynamic)MockResponse.responses, "United States", "Americas", "USA", @"\d{5}(-\d{4})?"),
            };
             string house = "No. 432";
             string city = "Generic City";
             string street = "Generic Street";

            foreach(Country country in countries)
            {
               
                Address address = new Address(country, city, street, house);

                Assert.Equal(address.Country.Name, country.Name);
                Assert.Equal(address.Country.Code, country.Code);
                Assert.Equal(address.Country.Continent, country.Continent);
                Assert.Equal(address.Country.PostalCodePattern, country.PostalCodePattern);
                Assert.Equal(address.City, city);
                Assert.Equal(address.Street, street);
                Assert.Equal(address.House, house);

            }         
        }
    }
}
