using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Models.Paging;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Models.SearchFilters;
using Xyz.Multitenancy.Data;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Security;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly ILogger<BillingController> _logger;
        private readonly ITenantAccessor<Tenant> _tenantAccessor;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        private readonly IBillingService _billingService;

        public BillingController(
            ILogger<BillingController> logger,
            ITenantAccessor<Tenant> tenantAccessor,
            MultitenancyDbContext multitenancyDbContext,
            IBillingService billingService)
        {
            this._logger = logger;
            this._tenantAccessor = tenantAccessor;
            this._multitenancyDbContext = multitenancyDbContext;
            this._billingService = billingService;
        }

        [HttpGet("invoices/search")]
        [Authorize(Policy = PolicyNames.RequireTenant)]
        public async Task<ActionResult<IEnumerable<BillingInvoiceDto>>> SearchBillingInvoices(
            [FromQuery] string? query,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string? column = "id",
            [FromQuery] SortDirection? direction = SortDirection.Descend,
            [FromQuery] int index = 0,
            [FromQuery] int size = 10)
        {
            var pageRequest = new PageRequest {
                Index = index,
                Size = size,
                Sort = new Sort { Column = column, Direction = direction }
            };
            
            var querySearchFilter = new DateRangeQuerySearchFilter { 
                Query = query, 
                StartDate = startDate, 
                EndDate = endDate 
            };

            var tenantId = this._tenantAccessor?.Tenant?.Id.ToString() ?? "";

            try
            {
                return Ok(await this._billingService.SearchBillingInvoices(tenantId, querySearchFilter, pageRequest));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching billing invoices!";
                var errorData = new {
                    Exception = ex.Message,
                    TenantId = tenantId,
                    SearchFilter = querySearchFilter,
                    PageRequest = pageRequest
                };
                this._logger.LogError(errorMessage, errorData);
                return BadRequest(errorMessage);                
            }
        }
    }
}
