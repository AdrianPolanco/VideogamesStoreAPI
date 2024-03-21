using System.Runtime.Serialization;
using VideogamesStore.Domain.Shared.Enums;
using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Exceptions.ValueObjects.Price
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