using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    [Index(nameof(ExternalCustomerId), IsUnique = true)]
    public class Company
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;

        [Column(TypeName = "varchar(256)")]
        public string? ExternalCustomerId { get; set; } = default!;

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
