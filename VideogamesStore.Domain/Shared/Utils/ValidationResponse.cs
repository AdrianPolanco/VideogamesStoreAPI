
using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Shared.Utils
{
    public class ValidationResponse
    {
        public bool HasErrors { get; private set; } = false;
        public int ErrorsQuantity { get; private set; }
        private List<Error> _errors = new List<Error>();
        public IReadOnlyList<Error> Errors => _errors;

        public void AddError(Error error) { 
            _errors.Add(error);
            if (HasErrors is false) HasErrors = true;
            ErrorsQuantity = _errors.Count();
        } 
    }
}
