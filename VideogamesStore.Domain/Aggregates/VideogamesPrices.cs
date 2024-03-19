
using VideogamesStore.Domain.Entities;
using VideogamesStore.Domain.Exceptions;

namespace VideogamesStore.Domain.Aggregates
{
    public class VideogamesPrices
    {
        public Guid VideoGameId { get; set; }
        public Videogame Videogame { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Price { get; private set; }

        public void SetPrice(decimal price)
        {
            if(price < 0) throw new InvalidVideogamePriceException(price);

            Price = price;
        }
    }
}
