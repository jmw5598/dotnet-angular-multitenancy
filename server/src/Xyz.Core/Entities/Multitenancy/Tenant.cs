using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Entities.Multitenancy
{
    /// <summary>
    /// Tenant information
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class Tenant
    {
        /// <summary>
        /// The tenant Id
        /// </summary>
        public Guid Id { get; set; } = default!;

        [Column(TypeName = "varchar(36)")]
        public string Guid { get; set; } = default!;

        /// <summary>
        /// The tenant identifier
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = default!;

        [Column(TypeName = "varchar(100)")]
        public string DisplayName { get; set; } = default!;

        /// <summary>
        /// A string which contains ip addresses which are comma delimited. Such as "97.198.174.206, 216.204.170.148"
        /// </summary>
        public string IpAddresses { get; set; } = default!;

        /// <summary>
        /// A string which contains domain names which are comma delimited. Such as "oiscus.com, slonds.com"
        /// </summary>
        public string DomainNames { get; set; } = default!;

        public string ConnectionString { get; set; } = default!;

        public bool IsActive { get; set; }

        public bool IsConfigured { get; set; }

        public Guid CompanyId { get; set; } = default!;
        public Company Company { get; set; } = default!;
        
        public Guid TenantPlanId { get; set; } = default!;
        public virtual TenantPlan TenantPlan { get; set; } = default!;

        public Guid? PaymentDetailsId { get; set; } = default!;
        public virtual PaymentDetails? PaymentDetails { get; set; } = default!;

        public TenantDto ToDto()
        {
            return new TenantDto
            {
                Id = this.Id,
                Name = this.Name,
                DisplayName = this.DisplayName,
                IsActive = this.IsActive,
                Company = this.Company.ToDto(),
                TenantPlan = this.TenantPlan?.ToDto() ?? null
            };
        }
    }
}
