

using VideogamesStore.Domain.Shared.Constants;

namespace VideogamesStore.Domain.Exceptions
{
    public class InvalidAddressException: Exception
    {
        public InvalidAddressException(string message, string parameterName, object value)
            : base($"{ErrorMessages.InvalidAddress}. {message}. The value you provided is {value} in {parameterName} ")
        {
            
        }
    }
}
