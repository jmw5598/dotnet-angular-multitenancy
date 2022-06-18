using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Core.Models.Multitenancy
{
    public class TenantStatistics
    {
        public TenantDto Tenant { get; set; } = default!;
        public int UserAccountsCount { get; set; } = default!;
        public DateTime? LastInvoiceDate { get; set; } = null!;
        public DateTime? NextInvoiceDate { get; set; } = null!;
    }
}
