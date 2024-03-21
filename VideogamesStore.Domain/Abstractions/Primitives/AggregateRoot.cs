
namespace VideogamesStore.Domain.Abstractions.Primitives
{
    public abstract class AggregateRoot: Entity
    {
        public AggregateRoot(Guid Id):base(Id) { }
    }
}
