using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Models;
using Xyz.Multitenancy.Security;

namespace Xyz.Api.Controllers
{
    [Authorize(Policy = PolicyNames.RequireTenant)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this._logger = logger;
            this._userService = userService;
        }
        
        [HttpGet("settings")]
        public async Task<ActionResult<object>> GetUserSettings()
        {
            try
            {
                // @TODO get user id
                return Ok(await this._userService.GetUserSettings("skjdflf"));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user settings!";
                this._logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<object>> GetUserPermissions()
        {
            try
            {
                // @TODO get user id
                return Ok(await this._userService.GetUserPermissions("kljsldkjfsdf"));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
                this._logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
        }
    }
}