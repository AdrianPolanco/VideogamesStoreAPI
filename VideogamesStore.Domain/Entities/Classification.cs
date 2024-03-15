
using VideogamesStore.Domain.Abstractions.Entities;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Classification: Auditable
    {
        public Classification(Rating rating)
        {
            Code = rating.Code;
            RecommendedAge = rating.RecommendedAge;
        }
        public string Code { get; set; }
        public int RecommendedAge { get; set; }
    }
}
