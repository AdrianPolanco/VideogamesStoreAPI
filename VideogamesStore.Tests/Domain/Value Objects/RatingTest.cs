using VideogamesStore.Domain.Shared.Utils;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Tests.Domain.Value_Objects
{
    public class RatingTest
    {
        [Theory]
        [InlineData("ESRB T", 13)]
        [InlineData("PEGI 18", 18)]
        [InlineData("CERO B", 12)]
        [InlineData("ESRB M", 17)]
        [InlineData("-", 0)]
        public void RatingCreation_ShouldBe_Successful(string code, int age)
        {
            Rating rating = Rating.Create(code, age);
            ValidationResponse validation = Rating.Validate(code, age);

            Assert.Equal(rating.Code, code);
            Assert.Equal(rating.RecommendedAge, age);

            Assert.True(validation.HasErrors is false);
        }
    }
}
