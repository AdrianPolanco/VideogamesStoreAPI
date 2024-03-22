using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;

namespace VideogamesStore.Domain.Value_Objects
{


    public class Discount: ValueObject
    {
        private Discount(double percentage, string concept)
        {

        }
        public double Percentage { get; private set; }
        public string Concept { get; private set; }

        public static ValidationResponse Validate(double percentage, string concept)
        {
            ValidationResponse validation = new ValidationResponse();

            Error? conceptIsNull = Check.ValueIsNotEmpty(concept, "The discount must has a concept", nameof(concept));

            if (conceptIsNull is not null) validation.AddError(conceptIsNull);

            if (percentage < 0) { 
                validation.AddError(new Error(ErrorCause.InvalidNegativeDiscount, ErrorMessages.NegativeDiscount, percentage));
                return validation; 
            }  

            if (percentage > 40) { 
                validation.AddError(new Error(ErrorCause.InvalidDiscount, ErrorMessages.TooHighDiscount, percentage));
                return validation;
            }

            return validation;
        }

        public static Discount? Create(double percentage, string concept)
        {
            percentage = percentage / 100;

            if (Validate(percentage, concept).HasErrors is false) return new Discount(percentage, concept);

            return null;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Percentage;
            yield return Concept;
        }
    }
}
