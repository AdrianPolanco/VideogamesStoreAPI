

namespace VideogamesStore.Domain.Shared.Errors
{
    public class Error
    {
        public Error(ErrorCause cause, string message, object invalidValue)
        {
            Cause = cause;
            Message = message;
            InvalidValue = invalidValue;
        }

        public ErrorCause Cause { get; }
        public string Message { get; }
        public object InvalidValue { get; }
    }
}
