using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface IBillingService
    {
        public Task<Page<BillingInvoiceDto>> SearchBillingInvoices(
            string tenantId, DateRangeQuerySearchFilter filter, PageRequest pageRequest);
    }
}
