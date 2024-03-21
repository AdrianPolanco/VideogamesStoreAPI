namespace VideogamesStore.Domain.Shared.Errors
{
    public record ErrorMessages
    {
        public static readonly string NegativePrice = "The price cannot be less than 0";
        public static readonly string InvalidCurrency = "The currency provided is not allowed";
        public static readonly string InvalidAddress = "The address provided is not valid";
        public static readonly string NonExistentCountry = "Country must exist";
        public static readonly string NonExistentContinent = "Continent must exist";
        public static readonly string CountryNotMatchingContinent = "Country does not have the correct continent";
        public static readonly string CountryNotMatchingCode = "Country does not have the correct code";
        public static readonly string CountryNotMatchingPattern = "Country does not have the correct postal code pattern";
        public static readonly string InvalidCountryCode = "Country does not own the code provided";
        public static readonly string NegativeDiscount = "The discount cannot be less than 0%";
        public static readonly string TooHighDiscount = "The discount cannot exceed the 40%";
        public static readonly string InvalidRequiredValue = "The value is required and cannot be empty or null";
    }
}
