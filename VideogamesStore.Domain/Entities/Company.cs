using VideogamesStore.Domain.Abstractions.Primitives;

namespace VideogamesStore.Domain.Entities
{
    public class Company: Entity
    {
        public Company(Guid Id, string name, string code): base(Id) { 
            Name = name;
            Code = code;
        }

        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
