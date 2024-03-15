using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideogamesStore.Domain.Abstractions.Entities
{
    public abstract class Auditable: BaseAuditable
    {

        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
