

namespace VideogamesStore.Domain.Exceptions
{
    public class InvalidDiscountException: Exception
    {
        public InvalidDiscountException(string message): base(message)
        {
        }
    }
}
