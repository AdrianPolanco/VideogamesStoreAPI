using System.Runtime.Serialization;
using VideogamesStore.Domain.Shared.Constants;
using VideogamesStore.Domain.Shared.Enums;

namespace VideogamesStore.Domain.Exceptions
{
    public class NotAllowedCurrencyException : Exception
    {
        public NotAllowedCurrencyException(string message) : base($"{ErrorMessages.InvalidCurrency}. The currencies currently allowed are: {GetAllowedCurrencies()}")
        {
        }
        private static string GetAllowedCurrencies()
        {
            var allowedCurrencies = Enum.GetNames(typeof(AllowedCurrencies));
            var currencyNames = string.Join(", ", allowedCurrencies);
            return currencyNames;
        }
    }
}