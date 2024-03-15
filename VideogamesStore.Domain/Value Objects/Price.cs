

namespace VideogamesStore.Domain.Value_Objects
{
    public record class Price
    {
        public Price(string code, decimal amount) { 
            Code = code;
            Amount = amount;
        }

        public string Code { get; set; }
        public decimal Amount { get; set; }
    }
}
