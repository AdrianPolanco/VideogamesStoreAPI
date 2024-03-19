
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Shared.Constants;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Tests.Messages;
using Xunit.Abstractions;

namespace VideogamesStore.Tests.Domain.Value_Objects
{
    public class CountryTest
    {
        private ITestOutputHelper output;

        public CountryTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Country_ShouldBe_Created()
        {
            var country = Country.Create((dynamic)MockResponse.responses, "United States", "Americas", "USA", @"\d{5}(-\d{4})?");

            Assert.Equal("United States", country.Name);
        }

        [Fact]
        public void Country_ShouldNotBe_Created()
        {
            var invalidCountry = Assert.Throws<InvalidCountryException>(() => Country.Create(MockResponse.responses, "Narnia", "Americas", "USA", @"\d{5}(-\d{4})?"));
            var invalidContinent = Assert.Throws<InvalidCountryException>(() => Country.Create(MockResponse.responses, "Norway", "Narnia", "NOR", @"\d{4}"));
            var wrongContinent = Assert.Throws<InvalidCountryException>(() => Country.Create(MockResponse.responses, "Portugal", "Asia", "PRT", @"\d{4}-\d{3}"));
            var wrongCode = Assert.Throws<InvalidCountryException>(() => Country.Create(MockResponse.responses, "Russia", "Europe", "RSSS", @"\d{6}"));

            Assert.Throws<ArgumentNullException>(() => Country.Create(MockResponse.responses,"Russia", "Europe", "RSSS", ""));
            Assert.Contains(ErrorMessages.NonExistentCountry, invalidCountry.Message);
            Assert.Contains(ErrorMessages.NonExistentContinent, invalidContinent.Message);
            Assert.Contains(ErrorMessages.InvalidProvidedContinent, wrongContinent.Message);
            Assert.Contains(ErrorMessages.InvalidCountryCode, wrongCode.Message);
        }
    }
}


