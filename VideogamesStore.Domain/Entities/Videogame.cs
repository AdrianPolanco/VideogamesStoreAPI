
using VideogamesStore.Domain.Abstractions.Primitives;

namespace VideogamesStore.Domain.Entities
{
    public class Videogame: Entity
    {
        public Videogame(Guid Id) : base(Id) { }

        public string Name { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public Guid ClassificationId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
       // public Classification Classification { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
