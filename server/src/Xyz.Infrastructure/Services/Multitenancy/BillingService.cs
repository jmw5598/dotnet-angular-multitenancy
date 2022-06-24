using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;

using Xyz.Core.Entities.Multitenancy;

using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class BillingService : IBillingService
    {
        private readonly ILogger<BillingService> _logger;
        private readonly MultitenancyDbContext _multitenancyDbContext;

        public BillingService(
            ILogger<BillingService> logger,
            MultitenancyDbContext multitenancyDbContext)
        {
            this._logger = logger;
            this._multitenancyDbContext = multitenancyDbContext;
        }

        public async Task<Page<BillingInvoiceDto>> SearchBillingInvoices(
            string tenantId, 
            DateRangeQuerySearchFilter filter, 
            PageRequest pageRequest)
        {
            try
            {
                IQueryable<BillingInvoice> query = this._multitenancyDbContext.BillingInvoices
                    .Include(bi => bi.Tenant);

                if (filter?.Query != null)
                {
                    var queryTerm = filter.Query.Trim().ToLower();
                    query = query.Where(bi => 
                        bi.AmountPaid.ToString().Contains(queryTerm)
                            || nameof(bi.Status).ToString().ToLower().Contains(queryTerm));
                }

                if (filter?.StartDate != null && filter?.EndDate != null)
                {
                    query = query
                        .Where(bi => bi.TransactionDate.Date >= filter.StartDate.Value.Date)
                        .Where(bi => bi.TransactionDate.Date <= filter.EndDate.Value.AddDays(1).Date);
                }
                else if (filter?.StartDate != null)
                {
                    query = query
                        .Where(bi => bi.TransactionDate.Date >= filter.StartDate.Value.Date);
                }
                else if (filter?.EndDate != null)
                {
                    query = query
                        .Where(bi => bi.TransactionDate.Date <= filter.EndDate.Value.AddDays(1).Date);
                }

                if (pageRequest.Sort != null)
                {
                    switch (pageRequest.Sort.Column)
                    {
                        case "transactionDate":
                            query = pageRequest.Sort.Direction == SortDirection.Ascend
                                ? query.OrderBy(bi => bi.TransactionDate)
                                : query.OrderByDescending(bi => bi.TransactionDate);
                            break;
                        case "amountPaid":
                            query = pageRequest.Sort.Direction == SortDirection.Ascend
                                ? query.OrderBy(bi => bi.AmountPaid)
                                : query.OrderByDescending(bi => bi.AmountPaid);
                            break;
                        case "status":
                            query = pageRequest.Sort.Direction == SortDirection.Ascend
                                ? query.OrderBy(bi => bi.Status)
                                : query.OrderByDescending(bi => bi.Status);
                            break;
                        default:
                            query = query.OrderByDescending(t => t.TransactionDate);
                            break;
                    }
                }
                    
                var billingInvoicesSource = query
                    .Select(bi => bi.ToDto());

                return await Page<BillingInvoiceDto>.From(billingInvoicesSource, pageRequest);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching billing invoices!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }
    }
}