using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;
using VideogamesStore.Domain.Value_Objects;
using VideogamesStore.Tests.Messages;
using Xunit.Abstractions;

namespace VideogamesStore.Tests.Domain.Value_Objects
{
    public class CountryTest
    {
        private ITestOutputHelper output;
        private static List<dynamic> countries = MockResponse.responses;

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

        [Theory]
        [InlineData("Narnia", "Americas", "USA", @"\d{5}(-\d{4})?")]
        [InlineData("Norway", "Narnia", "NOR", @"\d{4}")]
        [InlineData("Portugal", "Asia", "PRT", @"\d{4}-\d{3}")]
        [InlineData("Russia", "Europe", "RSSS", @"\d{6}")]
        public void Country_ShouldNotBe_Created(string country, string continent, string code, string postalCodePattern)
        {
            var invalidCountry = Country.Create(countries, country, continent, code, postalCodePattern);
            Assert.True(invalidCountry is null);
        }

        [Theory]
        [InlineData("Narnia", "Americas", "USA", @"\d{5}(-\d{4})?")]
        [InlineData("Dinoland", "Narnia", "NOR", @"\d{4}")]
        [InlineData("Random", "Asia", "PRT", @"\d{4}-\d{3}")]
        [InlineData("NonValidCountry", "Europe", "RSSS", @"\d{6}")]
        public void Error_Should_Contain_CountryName(string country, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Country.Validate(countries, country, continent, code, postalCodePattern);
            Assert.True(validation.Errors.Count() is <= 2);
            Assert.Equal(validation.Errors[0].Cause, ErrorCause.NonExistentCountry);

            if (validation.Errors.Count() > 1) Assert.Equal(validation.Errors[1].Cause, ErrorCause.NonExistentContinent);
        }

        [Theory]
        [InlineData("", "", "USA", @"\d{5}(-\d{4})?")]
        [InlineData("", "", "NOR", @"\d{4}")]
        [InlineData("", "", "PRT", @"\d{4}-\d{3}")]
        [InlineData("", "", "RSSS", @"\d{6}")]
        public void ErrorsCount_ShouldBe_Two(string country, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Country.Validate(countries, country, continent, code, postalCodePattern);
            Assert.True(validation.Errors.Count() is 2);
            Assert.Equal(validation.Errors[0].Cause, ErrorCause.RequiredValueIsNullOrEmpty);
            Assert.Equal(validation.Errors[1].Cause, ErrorCause.RequiredValueIsNullOrEmpty);
        }

        [Theory]
        [InlineData("Spain", "Americas", "USA", @"\d{5}(-\d{4})?")]
        [InlineData("Norway", "Oceania", "NOR", @"\d{4}")]
        [InlineData("Portugal", "Asia", "PRT", @"\d{4}-\d{3}")]
        [InlineData("Russia", "Africa", "RSSS", @"\d{6}")]
        public void Errors_ShouldContain_CountryNotMatchingContinentError(string country, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Country.Validate(countries, country, continent, code, postalCodePattern);
            Assert.True(validation.Errors.Any(x => x.Cause == ErrorCause.CountryNotMatchingContinent));
        }

        [Theory]
        [InlineData("Spain", "Americas", "USA", @"\d{5}(-\d{4})?")]
        [InlineData("Norway", "Oceania", "YRW", @"\d{4}")]
        [InlineData("Portugal", "Asia", "TRS", @"\d{4}-\d{3}")]
        [InlineData("Russia", "Africa", "RSSS", @"\d{6}")]
        public void Errors_ShouldContain_CountryNotMatchingCodeError(string country, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Country.Validate(countries, country, continent, code, postalCodePattern);
            Assert.True(validation.Errors.Any(x => x.Cause == ErrorCause.CountryNotMatchingCode));
        }

        [Theory]
        [InlineData("United States", "Americas", "USA", @"yGHFGB")]
        [InlineData("Norway", "Narnia", "NOR", @"\gfggf")]
        [InlineData("Portugal", "Asia", "PRT", @"65332")]
        [InlineData("Russia", "Europe", "RSSS", @"0000")]
        public void Errors_ShouldContain_CountryNotMatchindPatternError(string country, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Country.Validate(countries, country, continent, code, postalCodePattern);
            Assert.True(validation.Errors.Any(x => x.Cause == ErrorCause.CountryNotMatchingPattern));
        }
    }
}


