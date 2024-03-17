

using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Shared.Enums;

namespace VideogamesStore.Domain.Value_Objects
{
    public sealed record class Price
    {
        //private string[] Allowed_Currencies = new string[] { "USD", "EUR", "GBP", "DOP" };
        private Price(string code, decimal amount) { 
            Code = code;
            Amount = amount;
        }

        public string Code { get; private set; }
        public decimal Amount { get; private set; }

        public static Price Create(string code, decimal amount)
        {
            if (amount < 0) throw new InvalidPriceException(amount);

            bool isAllowedCurrency = Enum.IsDefined(typeof(AllowedCurrencies),code);
            if (isAllowedCurrency is false) throw new NotAllowedCurrencyException(code);

            return new Price(code, amount);
        } 
    }
}
