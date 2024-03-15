using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Company: Auditable
    {
        public Company() { }
        public Company(string name, string code) { 
            Name = name;
            Code = code;
        }

        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
