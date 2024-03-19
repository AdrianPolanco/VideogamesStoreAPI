

using System.ComponentModel.DataAnnotations.Schema;
using VideogamesStore.Domain.Abstractions.Primitives.Entities;
using VideogamesStore.Domain.Exceptions;
using VideogamesStore.Domain.Shared.Enums;

namespace VideogamesStore.Domain.Value_Objects
{
    [ComplexType]
    public sealed class Price: ValueObject
    {
        //private string[] Allowed_Currencies = new string[] { "USD", "EUR", "GBP", "DOP" };
        public Price(string code, decimal amount) {
            Create(code, amount);
            Code = code;
            Amount = amount;
        }

        public string Code { get; private set; }
        public decimal Amount { get; private set; }

        private static void Create(string code, decimal amount)
        {
            if (amount < 0) throw new InvalidPriceException(amount);

            bool isAllowedCurrency = Enum.IsDefined(typeof(AllowedCurrencies),code);
            if (isAllowedCurrency is false) throw new NotAllowedCurrencyException(code);

        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Amount;
        }
    }
}
