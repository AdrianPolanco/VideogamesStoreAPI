

using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Shared.Constants
{
    public record ErrorMessages
    {
        public static readonly string NegativePrice = "The price cannot be less than 0";
        public static readonly string InvalidCurrency = "The currency provided is not allowed";
        public static readonly string InvalidAddress = "The address provided is not valid";
        public static readonly string InvalidCountry = "The country provided is not valid";
        public static readonly string NonExistentCountry = "Country must exist";
        public static readonly string NonExistentContinent = "Continent must exist";
        public static readonly string InvalidProvidedContinent = "Country does not have the correct continent";
        public static readonly string InvalidCountryCode = "Country does not own the code provided";
    }
}
