

using VideogamesStore.Domain.Shared.Errors;

namespace VideogamesStore.Domain.Shared.Utils
{
    public static class Check
    {
        public static Error? GuidIsNotEmpty(Guid id, string message, string argument)
        {
            if (id == Guid.Empty) return new Error(ErrorCause.GuidIsNull, $"{message}. Error occurred in {argument}.", id);
            return null;
        }
        public static Error? ValueIsNotEmpty(string value, string message, string argument)
        {
            if(string.IsNullOrWhiteSpace(value)) return new Error(ErrorCause.RequiredValueIsNullOrEmpty, $"{message}. Error occurred in {argument}.", value);
            return null;
        }

        public static Error? InstanceIsNotNull<T>(T instance, string message, string argument)
        {
            if(instance is null ) return new Error(ErrorCause.RequiredInstanceIsNull, $"{message}. Error occurred in {argument}.", instance);
            return null;
        }
    }
}
