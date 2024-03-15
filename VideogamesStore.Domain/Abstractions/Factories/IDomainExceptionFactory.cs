

namespace VideogamesStore.Domain.Abstractions.Factories
{
    public interface IDomainExceptionFactory
    {
        Exception Create<T>(string message, T cause);
    }
}
