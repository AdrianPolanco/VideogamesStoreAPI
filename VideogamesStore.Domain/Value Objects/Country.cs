

using System.Text.RegularExpressions;
using VideogamesStore.Domain.Abstractions.Primitives.Entities;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Shared.Constants;

namespace VideogamesStore.Domain.Value_Objects
{
    public class Country : ValueObject
    {

        private Country(string name, string continent, string code, string postalCodePattern) {
            Name = name;
            Continent = continent;
            Code = code;
            PostalCodePattern = postalCodePattern;
        }

        public string Name { get; private set; }
        public string Continent { get; private set; }
        public string PostalCodePattern { get; private set; }
        public string Code { get; private set; }

        public static Country Create(List<dynamic> validCountries, string name, string continent, string code, string postalCodePattern)
        {
            Validate(validCountries, name.Trim(), continent.Trim(), code.Trim(), postalCodePattern);
            return new Country(name.Trim(), continent.Trim(), code.Trim(), postalCodePattern);

        }

        private static void Validate(List<dynamic> validCountries, string name, string continent, string code, string postalCodePattern)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(continent) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(postalCodePattern)) throw new ArgumentNullException();
            bool countryExists = validCountries.Any(c => c.Name == name);
            if (!countryExists) throw new InvalidCountryException(ErrorMessages.NonExistentCountry, nameof(name), name);

            bool continentExists = validCountries.Any(c => c.Continent == continent);
            if (!continentExists) throw new InvalidCountryException(ErrorMessages.NonExistentContinent, nameof(continent), continent);

            var matchedCountry = validCountries.FirstOrDefault(c => c.Name == name);

            bool countryMatchesContinent = matchedCountry.Continent.Equals(continent);
            if (!countryMatchesContinent) throw new InvalidCountryException(ErrorMessages.InvalidProvidedContinent, nameof(continent), continent);

            bool codeIsValid = matchedCountry.Code.Equals(code);

            if (!codeIsValid) throw new InvalidCountryException(ErrorMessages.InvalidCountryCode, nameof(code), code);
 }
            /*  var postalCodePattern = matchedCountry.Pattern;

              Regex regex = new Regex(postalCodePattern, RegexOptions.Compiled);

              if (!regex.IsMatch(postalCode)) throw new InvalidCountryException("Postal code provided is not valid in the country provided", nameof(postalCode), postalCode);*/

       
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Continent;
            yield return PostalCodePattern;
            yield return Code;
        }
    }
}
