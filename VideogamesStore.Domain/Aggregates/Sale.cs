

using VideogamesStore.Domain.Abstractions.Entities;
using VideogamesStore.Domain.Entities;

namespace VideogamesStore.Domain.Aggregates
{
    public class Sale: BaseAuditable
    {
        public Guid VideogamePriceId { get; set; }
        public VideogamesPrices VideogamesPrices { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal SoldFor { get; set; }

    }
}
