
using VideogamesStore.Domain.Abstractions.Primitives.Entities;
using VideogamesStore.Domain.Entities;
using VideogamesStore.Domain.Exceptions;

namespace VideogamesStore.Domain.Aggregates
{
    public class Order: Entity
    {
        public Order(Guid Id) : base(Id)
        {
            
        }
        public decimal Total { get; private set; }
        public List<Sale> Sales { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public bool HasDiscount { get; set; }
        public double DiscountPercentage { get; private set; } 

        public void CalculateTotal()
        {
            Total = Sales.Sum(s => s.SoldFor);
        }

        public void CalculateDiscount(decimal discountPercentage)
        {
            if (discountPercentage > 100) throw new InvalidDiscountException($"The discount: {discountPercentage} is too large. Discount can not be greater than 100");

            if (discountPercentage > 100) throw new InvalidDiscountException($"The discount: {discountPercentage} is too large. Discount can not be greater than 100");

            Total = (Total * discountPercentage) / 100;
        }
    }

    
}
