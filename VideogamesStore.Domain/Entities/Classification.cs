
using VideogamesStore.Domain.Abstractions.Primitives.Entities;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Classification: Entity
    {
        public Classification(Guid Id, Rating rating):base(Id)
        {
            Code = rating.Code;
            RecommendedAge = rating.RecommendedAge;
        }
        public string Code { get; set; }
        public int RecommendedAge { get; set; }
    }
}
