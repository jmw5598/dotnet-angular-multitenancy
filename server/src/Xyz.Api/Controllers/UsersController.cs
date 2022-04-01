using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Models;
using Xyz.Multitenancy.Security;

namespace Xyz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ILogger<UsersController> _logger;
        private IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            this._logger = logger;
            this._usersService = usersService;
        }

        [HttpGet("verify/email")]
        public async Task<ActionResult<ValidationResult>> VerifyEmail([FromQuery] string email)
        {
            try
            {
                return Ok(await this._usersService.VerifyEmail(email));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error verifying email!";
                this._logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
        }

        [HttpHead("verify/username")]
        public async Task<ActionResult<ValidationResult>> VerifyUserName([FromQuery] string userName)
        {
            try
            {
                return Ok(await this._usersService.VerifyUserName(userName));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error verifying email!";
                this._logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
        }
    }
}