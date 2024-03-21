using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Tests.Messages
{
    public record ExpectedTestMessages
    {
        public static readonly string InvalidCurrency = $"{ErrorMessages.InvalidCurrency}. The currencies currently allowed are: USD, EUR, GBP, DOP";
        public static readonly string InvalidAmount = $"{ErrorMessages.NegativePrice}: The value provided is ";
    }
}
