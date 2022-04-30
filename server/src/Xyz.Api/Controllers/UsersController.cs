using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
using Xyz.Core.Dtos;
using Xyz.Multitenancy.Security;
using Xyz.Multitenancy.Multitenancy;

using Xyz.Api.Models;

namespace Xyz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ILogger<UsersController> _logger;
        private IUsersService _usersService; // Multitenancy user specific stuff
        private IUserService _userService; // Users Serviec to tenant speicific stuff
        private IPermissionsService _permissionsService;
        private ITenantAccessor<Tenant> _tenantAccessor;

        public UsersController(
            ILogger<UsersController> logger, 
            IUsersService usersService,
            IUserService userService,
            IPermissionsService permissionsService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._usersService = usersService;
            this._userService = userService;
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

        [Authorize(Policy = PolicyNames.RequireTenant)]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAccount(CreateUserAccountDto createUserAccountDto)
        {
            var tenantId = this._tenantAccessor.Tenant.Id;
            
            try
            {
                var registrationUserAccount = createUserAccountDto.ToUserAccount();

                var newUserDto = await this._usersService
                    .CreateUserAccount(tenantId.ToString(), registrationUserAccount);
                
                var newUserPermissions = await this._userService
                    .SaveUserPermissions(newUserDto.Id.ToString(), registrationUserAccount.UserPermissions);
                
                return Ok(newUserDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating new user account!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        // @TODO will have to fix this
        [HttpGet("{userId}/permissions")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<UserPermission>>> GetUserPermissions([FromRoute] string userId)
        {
            try
            {
                return Ok(await this._userService.GetUserPermissions(userId));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
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