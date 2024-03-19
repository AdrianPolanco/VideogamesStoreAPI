
using VideogamesStore.Domain.Abstractions.Primitives.Entities;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Currency: Entity
    {
        public Currency(Guid Id, string name, Price price) : base(Id)
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