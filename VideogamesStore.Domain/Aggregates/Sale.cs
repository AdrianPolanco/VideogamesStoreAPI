
using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Entities;

namespace VideogamesStore.Domain.Aggregates
{
    public class Sale: Entity
    {
        public Sale(Guid Id): base(Id)
        {
            
        }
        public Guid VideogamePriceId { get; set; }
        public VideogamesPrices VideogamesPrices { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal SoldFor { get; set; }

    }
}
