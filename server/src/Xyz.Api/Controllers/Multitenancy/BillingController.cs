using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

using Xyz.Core.Models.Configuration;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Models.SearchFilters;
using Xyz.Multitenancy.Data;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Security;

using Stripe;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly ILogger<BillingController> _logger;
        private readonly IOptions<StripeSettings> _stripeSettings;
        private readonly ITenantAccessor<Tenant> _tenantAccessor;
        private readonly MultitenancyDbContext _multitenancyDbContext;
        private readonly IBillingService _billingService;
        private readonly IPaymentProcessorService _paymentProcessorService;

        public BillingController(
            ILogger<BillingController> logger,
            IOptions<StripeSettings> stripeSettings,
            ITenantAccessor<Tenant> tenantAccessor,
            MultitenancyDbContext multitenancyDbContext,
            IBillingService billingService,
            IPaymentProcessorService paymentProcessorService)
        {
            this._logger = logger;
            this._stripeSettings = stripeSettings;
            this._tenantAccessor = tenantAccessor;
            this._multitenancyDbContext = multitenancyDbContext;
            this._billingService = billingService;
            this._paymentProcessorService = paymentProcessorService;
        }

        [HttpPost("stripe/webhook")]
        public async Task<object> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Event stripeEvent;
            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json, Request.Headers["Stripe-Signature"], this._stripeSettings.Value.SecretKey);
                
                await this._paymentProcessorService.ProcessWebhook<Event>(stripeEvent);
                
                return Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = "Something went wrong when processing Stripe event!";
                var errorData = new { Exception = ex.Message, Event = json };
                this._logger.LogError(errorMessage, errorData);
                return BadRequest();
            }
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
