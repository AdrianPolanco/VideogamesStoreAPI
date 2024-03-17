

using VideogamesStore.Domain.Shared.Enums;

namespace VideogamesStore.Domain.Shared.Constants
{
    public record ErrorMessages
    {
        public static readonly string NegativePrice = "The price cannot be less than 0";
        public static readonly string InvalidCurrency = "The currency provided is not allowed";
    }
}
