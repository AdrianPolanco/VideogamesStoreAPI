

using VideogamesStore.Domain.Abstractions.Primitives.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Customer: Entity
    {
        public Customer(Guid Id) : base(Id)
        {
            
        }
        public string Name { get; set; }
        public string LastName { get; set; }    
        public DateTimeOffset BirthDate { get; set; }
        public List<Address> AddressList { get; set; }
    }
}
