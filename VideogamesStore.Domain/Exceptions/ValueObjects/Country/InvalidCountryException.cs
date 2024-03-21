using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Exceptions.ValueObjects.Country
{
    public class InvalidCountryException : Exception
    {
        public InvalidCountryException(string message, string parameterName, object value)
            : base($"{ErrorMessages.NonExistentCountry}. {message}. The value you provided is {value} in {parameterName} ")
        {

        }
    }
}
