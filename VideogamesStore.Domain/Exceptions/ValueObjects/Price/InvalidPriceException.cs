using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Exceptions.ValueObjects.Price
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(decimal price) : base($"{ErrorMessages.NegativePrice}: The value provided is {price}") { }
    }
}
