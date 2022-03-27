using Microsoft.AspNetCore.Mvc;
using Xyz.Core.Interfaces;

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

        [HttpHead("verify/email")]
        public async Task<ActionResult> VerifyEmail([FromQuery] string email)
        {
            try
            {
                var isEmailInUse = await this._usersService.VerifyEmail(email);

                if (isEmailInUse)
                {
                    return NoContent();
                }

                return NotFound("Email is currently not in use!");
            }
            catch (Exception ex)
            {
                this._logger.LogError("Errer verifying email!");
                return BadRequest("Error verifying email!");
            }
        }

        [HttpHead("verify/username")]
        public async Task<ActionResult> VerifyUserName([FromQuery] string userName)
        {
            try
            {
                var isEmailInUse = await this._usersService.VerifyUserName(userName);
                
                if (isEmailInUse)
                {
                    return NoContent();
                }

                return NotFound("Username is currently not in use!");
            }
            catch (Exception ex)
            {
                this._logger.LogError("Errer verifying email!");
                return BadRequest("Error verifying email!");
            }
        }
    }
}