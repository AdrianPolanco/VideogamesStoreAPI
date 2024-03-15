using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Address: Auditable
    {
        public string CountryCode { get; set; }
        public string State {  get; set; }  
        public string City { get; set; }    
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
