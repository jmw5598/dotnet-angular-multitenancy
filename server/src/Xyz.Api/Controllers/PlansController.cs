using Microsoft.AspNetCore.Mvc;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Interfaces;

namespace Xyz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private ILogger<PlansController> _logger;
        private IPlansService _plansService;

        public PlansController(ILogger<PlansController> logger, IPlansService plansService)
        {
            this._logger = logger;
            this._plansService = plansService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> FindAll()
        {
            try
            {
                return Ok(await this._plansService.FindAll());
            }
            catch (Exception ex)
            {
                this._logger.LogError("Errer getting plans!", new { Exception = ex });
                return BadRequest("Error getting plans!");
            }
        }
    }
}
