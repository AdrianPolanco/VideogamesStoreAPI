

using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Customer: Auditable
    {
        public string Name { get; set; }
        public string LastName { get; set; }    
        public DateTimeOffset BirthDate { get; set; }
        public List<Address> AddressList { get; set; }
    }
}
