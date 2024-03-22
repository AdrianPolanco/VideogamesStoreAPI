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
        public static readonly string EmptyOrNullRequiredValue = "The value is required and cannot be empty or null";
        public static readonly string InvalidFormat = "The value is in an invalid format. Make sure it matches the required pattern.";
        public static readonly string InvalidAge = "The age you provided is not valid.";
        public static readonly string InvalidRatingCode = "The rating code you provided is not valid. If the videogames has no rating just use '-' to indicate it.";
        public static readonly string AgeProvidedNotMatchingEmptyCode = "If your videogame has no rating, its recommended age is zero. Provide a rating or change the age to zero.";
        public static readonly string InvalidDate = "The date you provided is invalid.";
        public static readonly string InvalidFutureReleaseDate = "The release date you provided is invalid. In the case of video games yet to be released, they can only be registered if they are going to be released in the next 2 years from the current date.";
        public static readonly string InvalidPastReleaseDate = "The date you provided is invalid. The products older than five years are discontinued.";
        public static readonly string GuidIsNull = "The GUID you provided is null or invalid.";
    }
}
