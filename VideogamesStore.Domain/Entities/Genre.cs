

using VideogamesStore.Domain.Abstractions.Primitives;

namespace VideogamesStore.Domain.Entities
{
    public class Genre: Entity
    {
        public Genre(Guid Id, string name, string description) : base(Id)
        { 
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
