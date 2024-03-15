
using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class PaymentMethod: Auditable
    {
        public string Name { get; set; }
        public bool IsBeingAccepted { get; set; }

    }
}
