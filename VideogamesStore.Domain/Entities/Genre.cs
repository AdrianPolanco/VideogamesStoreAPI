
using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Genre: Auditable
    {
        public Genre() { }
        public Genre(string name, string description) { 
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
