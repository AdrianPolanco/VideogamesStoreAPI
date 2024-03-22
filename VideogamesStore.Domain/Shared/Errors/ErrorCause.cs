

namespace VideogamesStore.Domain.Shared.Errors
{
    public enum ErrorCause
    {
        NegativePrice,
        NotAllowedCurrency,
        InvalidAddress,
        NonExistentCountry,
        NonExistentContinent,
        CountryNotMatchingContinent,
        CountryNotMatchingCode,
        CountryNotMatchingPattern,
        InvalidCountryCode,
        InvalidNegativeDiscount,
        InvalidDiscount,
        GuidIsNull,
        RequiredValueIsNullOrEmpty,
        RequiredInstanceIsNull,
        InvalidFormat,
        InvalidAge,
        InvalidRatingCode,
        AgeProvidedNotMatchingEmptyCode,
        InvalidFutureReleaseDate,
        InvalidPastReleaseDate
    }
}
