
using VideogamesStore.Domain.Shared.Constants;

namespace VideogamesStore.Domain.Exceptions
{
    public class InvalidPriceException: Exception
    {
        public InvalidPriceException(decimal price):base($"{ErrorMessages.NegativePrice}: {nameof(price)} is {price}") { }
    }
}
