using System.Text.RegularExpressions;
using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;

namespace VideogamesStore.Domain.Value_Objects
{
    public class Rating: ValueObject
    {

        private Rating(string code, int recommendedAge)
        {
            Code = code;
            RecommendedAge = recommendedAge;
        }

        public string Code { get; private set; }
        public int RecommendedAge { get; private set; }

        internal static Rating? Create(string code, int recommendedAge)
        {
            if(Validate(code, recommendedAge).HasErrors is false) return new Rating(code, recommendedAge);
            return null;
        }

        internal static ValidationResponse Validate(string code, int recommendedAge)
        {
            ValidationResponse validation = new();
            Error? isCodeNull = Check.ValueIsNotEmpty(code,ErrorMessages.EmptyOrNullRequiredValue, nameof(code));

            if (isCodeNull is not null) validation.AddError(isCodeNull);
            if (code is "-" && recommendedAge is not 0) validation.AddError(new Error(ErrorCause.AgeProvidedNotMatchingEmptyCode, ErrorMessages.AgeProvidedNotMatchingEmptyCode, new object[] { code, recommendedAge}));
            if (CodeMatchesPattern(code) is false) validation.AddError(new Error(ErrorCause.InvalidRatingCode, ErrorMessages.InvalidRatingCode, code));
            if(recommendedAge < 0) validation.AddError(new Error(ErrorCause.InvalidAge, ErrorMessages.InvalidAge, recommendedAge));

            return validation;
        }

        private static bool CodeMatchesPattern(string code)
        {
            var regex = new Regex(@"^[A-Z0-9\s-]{1,12}$");
            return regex.IsMatch(code); 
        }


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return RecommendedAge;
        }
    }
}
