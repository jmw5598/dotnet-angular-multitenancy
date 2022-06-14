using Microsoft.AspNetCore.Mvc;

using Xyz.Core.Models.Paging;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Interfaces;
using Xyz.Core.Models.SearchFilters;
using Xyz.Multitenancy.Data;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private ILogger<BillingController> _logger;

        public BillingController(ILogger<BillingController> logger, MultitenancyDbContext multitenancyDbContext)
        {
            this._logger = logger;
        }

        [HttpGet("invoices/search")]
        public async Task<ActionResult<IEnumerable<BillingInvoiceDto>>> SearchBillingInvoices(
            [FromQuery] string? query,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string column = "id",
            [FromQuery] SortDirection direction = SortDirection.Descend,
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

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}
