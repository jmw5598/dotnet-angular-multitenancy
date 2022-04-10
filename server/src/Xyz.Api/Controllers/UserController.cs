using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;

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
        public async Task<ActionResult<UserSettings>> GetUserSettings()
        {
            try
            {
                string? userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Unauthorized!");
                }

                return Ok(await this._userService.GetUserSettings(userId));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user settings!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<UserPermissions>> GetUserPermissions()
        {
            try
            {
                string? userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Unauthorized!");
                }

                return Ok(new UserPermissions {
                    Permissions = await this._userService.GetUserPermissions(userId)
                });
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }
    }
}