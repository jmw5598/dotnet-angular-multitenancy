using Xyz.Core.Dtos;

namespace Xyz.Core.Models
{
    public class TenantStatistics
    {
        public TenantDto Tenant { get; set; } = default!;
        public int UserAccountsCount { get; set; } = default!;
    }
}
