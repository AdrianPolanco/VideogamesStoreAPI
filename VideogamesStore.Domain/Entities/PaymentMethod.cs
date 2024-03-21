﻿

using VideogamesStore.Domain.Abstractions.Primitives;

namespace VideogamesStore.Domain.Entities
{
    public class PaymentMethod: Entity
    {
        public PaymentMethod(Guid Id) : base(Id) 
        {
            
        }
        public string Name { get; set; }
        public bool IsBeingAccepted { get; set; }

    }
}
