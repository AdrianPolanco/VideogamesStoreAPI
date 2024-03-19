

namespace VideogamesStore.Persistence.Models.Core
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
