

using VideogamesStore.Domain.Abstractions.Primitives;

namespace VideogamesStore.Domain.Value_Objects
{
    public class Rating: ValueObject
    {

        public Rating(string code, int recommendedAge)
        {
            Code = code;
            RecommendedAge = recommendedAge;
        }

        public string Code { get; private set; }
        public int RecommendedAge { get; private set; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return RecommendedAge;
        }
    }
}
