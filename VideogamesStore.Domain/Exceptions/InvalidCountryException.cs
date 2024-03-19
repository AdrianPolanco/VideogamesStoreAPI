

using VideogamesStore.Domain.Shared.Constants;

namespace VideogamesStore.Domain.Exceptions
{
    public class InvalidCountryException: Exception
    {
        public InvalidCountryException(string message, string parameterName, object value)
            : base($"{ErrorMessages.InvalidCountry}. {message}. The value you provided is {value} in {parameterName} ")
        {
            
        }
    }
}
