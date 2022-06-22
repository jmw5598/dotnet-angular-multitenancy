using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Models;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Models.Multitenancy;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Dtos.Multitenancy;
using Xyz.Core.Entities.Multitenancy;

using Xyz.Multitenancy.Security;
using Xyz.Multitenancy.Multitenancy;

using Xyz.Api.Models;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private ILogger<TenantsController> _logger;
        private ITenantsService _tenantsService;
        private ITenantAccessor<Tenant> _tenantAccessor;

        public TenantsController(
            ILogger<TenantsController> logger,
            ITenantsService tenantsService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._tenantsService = tenantsService;
            this._tenantAccessor = tenantAccessor;
        }

        [HttpGet("statistics")]
        [Authorize(Policy = PolicyNames.RequireTenant)]
        public async Task<ActionResult<TenantStatistics>> GetTenantStatistics()
        {
            try
            {
                var tenantId = this._tenantAccessor.Tenant.Id.ToString() ?? "";
                return Ok(await this._tenantsService.GetTenantStatisticsAsync(tenantId));
            }
            catch (Exception ex)
            {
                this._logger.LogError($"There was an error getting tenant statistics!");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpGet("from-subdomain")]
        public async Task<ActionResult<TenantDto>> FindTenantFromSubdomain([FromQuery] string subdomain)
        {
            try
            {
                return Ok(await this._tenantsService.FindTenantFromSubdomainAsync(subdomain));
            }
            catch (Exception ex)
            {
                this._logger.LogError($"There was an error, {ex.Message}");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = ex.Message
                    }
                );
            }
        }

        [HttpPost]
        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegistrationDto registrationDto)
        {
            try
            {
                return Ok(
                    await this._tenantsService.RegisterAsync(registrationDto.ToRegistration())
                );
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = e.Message
                    }
                );
            }
        }

        [HttpGet("companies/search")]
        public async Task<ActionResult<Page<TenantDto>>> SearchCompanies(
            [FromQuery] string? query = null,
            [FromQuery] string column = "id",
            [FromQuery] SortDirection direction = SortDirection.Ascend,
            [FromQuery] int index = 0,
            [FromQuery] int size = 10)
        {
            var filter = new BasicQuerySearchFilter { Query = query };
            var pageRequest = new PageRequest { 
                Index = index, 
                Size = size,
                Sort = new Sort { Column = column, Direction = direction }    
            };
            try
            {
                return Ok(
                    await this._tenantsService.SearchCompaniesAsync(filter, pageRequest)
                );
            }
            catch (Exception e)
            {
                var errorMessage = "Error searching companies!";
                this._logger.LogError(errorMessage, new { Exception = e });
                return BadRequest(errorMessage);
            }
        }
    }
}
