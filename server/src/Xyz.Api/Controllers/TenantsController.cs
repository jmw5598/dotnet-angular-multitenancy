using Microsoft.AspNetCore.Mvc;

using Xyz.Api.Models;
using Xyz.Core.Models;
using Xyz.Core.Interfaces;
using Xyz.Core.Dtos;

namespace Xyz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private ILogger<AuthenticationController> _logger;
        private ITenantsService _tenantsService;

        public TenantsController(
            ILogger<AuthenticationController> logger,
            ITenantsService tenantsService)
        {
            this._logger = logger;
            this._tenantsService = tenantsService;
        }

        [HttpGet("from-subdomain")]
        public async Task<ActionResult<TenantDto>> FindTenantFromSubdomain([FromQuery] string subdomain)
        {
            try
            {
                return Ok(await this._tenantsService.FindTenantFromSubdomain(subdomain));
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
    }
}
