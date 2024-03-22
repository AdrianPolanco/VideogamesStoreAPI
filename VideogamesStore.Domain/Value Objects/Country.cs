

using System.Text.RegularExpressions;
using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Exceptions.ValueObjects.Country;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;

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

        public static Country? Create(List<dynamic> validCountries, string name, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = Validate(validCountries, name.Trim(), continent.Trim(), code.Trim(), postalCodePattern);

            if(validation.HasErrors is false) return new Country(name.Trim(), continent.Trim(), code.Trim(), postalCodePattern);
            return null;

        }

        public static ValidationResponse Validate(List<dynamic> validCountries, string name, string continent, string code, string postalCodePattern)
        {
            ValidationResponse validation = new();
            //Validating if 
            if (Check.ValueIsNotEmpty(name, ErrorMessages.EmptyOrNullRequiredValue, name) is Error errorCountry && errorCountry is not null) validation.AddError(errorCountry);
            if (Check.ValueIsNotEmpty(continent, ErrorMessages.EmptyOrNullRequiredValue, continent) is Error errorContinent && errorContinent is not null) validation.AddError(errorContinent);
            if (validation.Errors.Count() >= 2) return validation;
            if (Check.ValueIsNotEmpty(code, ErrorMessages.EmptyOrNullRequiredValue, code) is Error errorCode && errorCode is not null) validation.AddError(errorCode);
            if (Check.ValueIsNotEmpty(postalCodePattern, ErrorMessages.EmptyOrNullRequiredValue, postalCodePattern) is Error errorPostalCode && errorPostalCode is not null) validation.AddError(errorPostalCode);
            /*if (string.IsNullOrEmpty(continent)) validation.AddError(new Error(ErrorCause.RequiredValueIsNullOrEmpty, ErrorMessages.InvalidRequiredValue, continent));
            if (string.IsNullOrEmpty(code)) validation.AddError(new Error(ErrorCause.RequiredValueIsNullOrEmpty, ErrorMessages.InvalidRequiredValue, code));
            if (string.IsNullOrEmpty(postalCodePattern)) validation.AddError(new Error(ErrorCause.RequiredValueIsNullOrEmpty, ErrorMessages.InvalidRequiredValue, postalCodePattern));*/

            

            bool countryExists = validCountries.Any(c => c.Name == name);
            if (!countryExists) validation.AddError(new Error(ErrorCause.NonExistentCountry, ErrorMessages.NonExistentCountry, name));

            bool continentExists = validCountries.Any(c => c.Continent == continent);
            if (!continentExists) validation.AddError(new Error(ErrorCause.NonExistentContinent, ErrorMessages.NonExistentContinent, continent));

            var matchedCountry = validCountries.FirstOrDefault(c => c.Name == name);

            if (matchedCountry is null) return validation;

            bool countryMatchesContinent = matchedCountry.Continent.Equals(continent);
            if (!countryMatchesContinent) validation.AddError(new Error(ErrorCause.CountryNotMatchingContinent, ErrorMessages.CountryNotMatchingContinent, continent));

            bool countryMatchesCode = matchedCountry.Code.Equals(code);
            if (!countryMatchesCode) validation.AddError(new Error(ErrorCause.CountryNotMatchingCode, ErrorMessages.CountryNotMatchingCode, code));

            bool codeIsValid = matchedCountry.Code.Equals(code);

            if (!codeIsValid) validation.AddError(new Error(ErrorCause.InvalidCountryCode, ErrorMessages.InvalidCountryCode, code));

            bool countryMatchesPattern = matchedCountry.Pattern.Equals(postalCodePattern);
            if (!countryMatchesPattern) validation.AddError(new Error(ErrorCause.CountryNotMatchingPattern, ErrorMessages.CountryNotMatchingPattern, postalCodePattern));

            return validation;
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
