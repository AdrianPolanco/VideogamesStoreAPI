

namespace VideogamesStore.Domain.Value_Objects
{
    public class Rating
    {

        public Rating(string code, int recommendedAge)
        {
            Code = code;
            RecommendedAge = recommendedAge;
        }

        public string Code { get; set; }
        public int RecommendedAge { get; set; }
    }
}
