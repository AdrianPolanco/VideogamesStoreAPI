

namespace VideogamesStore.Domain.Shared.Utils
{
    public static class Check
    {
        public static void GuidIsNotEmpty(Guid id, string message, string argument)
        {
            if (id == Guid.Empty) throw new ArgumentException(message, argument);
        }
        public static void ValueIsNotEmpty(string value, string message, string argument)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException(message, argument);
        }

        public static void InstanceIsNotNull<T>(T instance, string message, string argument)
        {
            if(instance is null ) throw new ArgumentNullException(message, argument);
        }
    }
}
