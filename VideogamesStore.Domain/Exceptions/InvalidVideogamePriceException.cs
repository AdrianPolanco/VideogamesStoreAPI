

namespace VideogamesStore.Domain.Exceptions
{
    public class InvalidVideogamePriceException : Exception
    {
        public decimal InvalidPrice { get; }

        public InvalidVideogamePriceException(decimal price)
            : base($"The price provided ({price}) is invalid. Price cannot be negative.")
        {
            InvalidPrice = price;
        }
    }

}
