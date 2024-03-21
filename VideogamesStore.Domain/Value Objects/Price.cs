
using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Exceptions.ValueObjects.Price;
using VideogamesStore.Domain.Shared.Enums;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;

namespace VideogamesStore.Domain.Value_Objects
{

    public sealed class Price: ValueObject
    {
        private Price(string code, decimal amount) {
            Code = code;
            Amount = amount;
        }

        public string Code { get; private set; }
        public decimal Amount { get; private set; }

        public static Price? Create(string code, decimal amount)
        {
            if(Price.Validate(code, amount).HasErrors is false) return new Price(code, amount);
            return null;
        }

        public static ValidationResponse Validate(string code, decimal amount)
        {
            ValidationResponse validationResponse = new();
            if (amount < 0) validationResponse.AddError(new Error(ErrorCause.NegativePrice, ErrorMessages.NegativePrice, amount));

            bool isAllowedCurrency = Enum.IsDefined(typeof(AllowedCurrencies), code.ToUpper());
            if (isAllowedCurrency is false) validationResponse.AddError(new Error(ErrorCause.NotAllowedCurrency, ErrorMessages.InvalidCurrency, code));

            return validationResponse;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Amount;
        }
    }
}
