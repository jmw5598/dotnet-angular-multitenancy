using Microsoft.AspNetCore.Mvc;

using Xyz.Core.Models;
using Xyz.Core.Interfaces;

namespace Xyz.Api.Controllers.Multitenancy
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ILogger<CompaniesController> _logger;
        private ICompaniesService _companiesService;

        public CompaniesController(ILogger<CompaniesController> logger, ICompaniesService companiesService)
        {
            this._logger = logger;
            this._companiesService = companiesService;
        }

        [HttpGet("exists")]
        public async Task<ActionResult<ValidationResult>> DoesCompanyNameExist([FromQuery] string companyName)
        {
            try
            {
                return Ok(await this._companiesService.DoesCompanyNameExistAsync(companyName));
            }
            catch (Exception ex)
            {
                this._logger.LogError("Errer getting plans!", new { Exception = ex });
                return BadRequest("Error getting plans!");
            }
        }
    }
}
