
using VideogamesStore.Domain.Abstractions.Entities;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Videogame: Auditable
    {
        public Videogame() { }

        public string Name { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public Guid ClassificationId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Classification Classification { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
