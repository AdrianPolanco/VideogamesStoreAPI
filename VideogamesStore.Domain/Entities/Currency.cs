using VideogamesStore.Domain.Abstractions.Entities;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Currency: Auditable
    {
        public Currency(string name, Price price)
        {
            Name = name;
            Code = price.Code;
            Value = price.Amount;
        }
        public string Name { get; init; }
        public string Code { get; init; }
        public decimal Value { get; set; }
    }
}