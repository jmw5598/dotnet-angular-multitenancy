using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    public class Company
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;

        public ICollection<Tenant> Tenants { get; set; } = default!;
    
        public CompanyDto ToDto()
        {
            return new CompanyDto
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
