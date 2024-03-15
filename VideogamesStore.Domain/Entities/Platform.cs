
using VideogamesStore.Domain.Abstractions.Entities;

namespace VideogamesStore.Domain.Entities
{
    public class Platform: Auditable
    {
        public Platform() { }

        public Platform(string name, string code, Guid companyId) { 
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
