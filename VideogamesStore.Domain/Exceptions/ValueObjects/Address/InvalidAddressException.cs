using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Exceptions.ValueObjects.Address
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message, string parameterName, object value)
            : base($"{ErrorMessages.InvalidAddress}. {message}. The value you provided is {value} in {parameterName} ")
        {

        }
    }
}
