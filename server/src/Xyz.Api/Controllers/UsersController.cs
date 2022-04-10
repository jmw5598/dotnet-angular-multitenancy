using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
using Xyz.Core.Dtos;
using Xyz.Multitenancy.Security;
using Xyz.Multitenancy.Multitenancy;

namespace Xyz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ILogger<UsersController> _logger;
        private IUsersService _usersService;
        private IPermissionsService _permissionsService;
        private ITenantAccessor<Tenant> _tenantAccessor;

        public UsersController(
            ILogger<UsersController> logger, 
            IUsersService usersService,
            IPermissionsService permissionsService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._usersService = usersService;
            this._permissionsService = permissionsService;
            this._tenantAccessor = tenantAccessor;
        }

        [Authorize(Policy = PolicyNames.RequireTenant)]
        [HttpGet("search")]
        public async Task<ActionResult<Page<UserDto>>> SearchUsersByTenant(
            [FromQuery] int? index = 0,
            [FromQuery] int? size = 20
        )
        {
            //@TODO figure out sort

            var tenantId = this._tenantAccessor.Tenant.Id;
            var pageRequest = new PageRequest
            {
                Index = index ?? 0,
                Size = size ?? 20
            };

            try
            {
                return Ok(await this._usersService.SearchUsersByTenant(tenantId.ToString(), pageRequest));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching users!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<IEnumerable<Permission>>> GetAssignablePermissions()
        {
            try
            {
                return Ok(await this._permissionsService.FindAll());
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting assignable permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
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
                this._logger.LogError(errorMessage, new { Exception = ex });
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
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }
    }
}