using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<ApplicationUser> Users { get; set; } = default!;
    }
}
