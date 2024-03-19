
using VideogamesStore.Domain.Abstractions.Primitives.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Platform: Entity
    {

        public Platform(Guid Id, string name, string code, Guid companyId) : base(Id)
        { 
            Name = name;
            Code = code;
            CompanyId = companyId;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CompanyId { get; init; }
        public Company Company { get; init; }

        public List<Videogame> Videogames { get; set; }

    }
}
