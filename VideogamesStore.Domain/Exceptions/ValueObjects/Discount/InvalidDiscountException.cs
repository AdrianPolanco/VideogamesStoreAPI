namespace VideogamesStore.Domain.Exceptions.ValueObjects.Discount
{
    public class InvalidDiscountException : Exception
    {
        public InvalidDiscountException(string message) : base(message)
        {
        }
    }
}
