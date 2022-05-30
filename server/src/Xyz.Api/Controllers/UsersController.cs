using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Multitenancy;
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

        public UsersController(
            ILogger<UsersController> logger, 
            IUsersService usersService,
            IUserService userService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._usersService = usersService;
            this._userService = userService;
        }

        [Authorize(Policy = PolicyNames.RequireTenant)]
        [HttpGet("search")]
        public async Task<ActionResult<Page<UserAccountDto>>> SearchUsersByTenant(
            [FromQuery] string? query = null,
            [FromQuery] int? index = 0,
            [FromQuery] int? size = 20)
        {
            var pageRequest = new PageRequest { Index = index ?? 0, Size = size ?? 20 };
            var querySearchFilter = new BasicQuerySearchFilter { Query = query };

            try
            {
                return Ok(await this._usersService.SearchUsers(querySearchFilter, pageRequest));
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
        public async Task<ActionResult<UserAccountDto>> CreateUserAccount(CreateUserAccountDto createUserAccountDto)
        {   
            try
            {
                var registrationUserAccount = createUserAccountDto.ToUserAccount();

                var newUserDto = await this._usersService
                    .CreateUserAccount(registrationUserAccount);
                
                // Assigns new AspNetUserId to the UserModulePermissions
                registrationUserAccount.UserModulePermissions = registrationUserAccount.UserModulePermissions
                    .Select(ump => 
                    {
                        ump.UserId = newUserDto.Id;
                        return ump;
                    })
                    .ToList();

                var newUserModulePermissions = await this._userService
                    .SaveUserModulePermissions(newUserDto.Id.ToString(), registrationUserAccount.UserModulePermissions);

                newUserDto.UserModulePermissions = newUserModulePermissions;
                
                return Ok(newUserDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating new user account!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserAccountDto>> GetUserAccountById([FromRoute] string userId)
        {
            try
            {
                var userAccountDto = await this._usersService.GetUserAccountByUserId(userId);
                var userModulePermissions = await this._userService.GetUserModulePermissions(userId);
                userAccountDto.UserModulePermissions = userModulePermissions;
                return Ok(userAccountDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user account!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [Authorize(Policy = PolicyNames.RequireTenant)]
        [HttpPut("{userId}")]
        public async Task<ActionResult<UserAccountDto>> UpdateUserAccount(
            [FromRoute] string userId, 
            [FromBody] UpdateUserAccountDto updateUserAccountDto)
        {    
            try
            {
                var updatedUserAccount = updateUserAccountDto.ToUserAccount();

                var updatedUserDto = await this._usersService
                    .UpdateUserAccount(userId, updatedUserAccount);
                
                // Assigns new AspNetUserId to the UserModulePermissions
                updatedUserAccount.UserModulePermissions = updatedUserAccount.UserModulePermissions
                    .Select(ump => 
                    {
                        ump.UserId = updatedUserDto.Id;
                        return ump;
                    })
                    .ToList();

                var newUserModulePermissions = await this._userService
                    .UpdateUserModulePermissions(updatedUserDto.Id.ToString(), updatedUserAccount.UserModulePermissions);

                updatedUserDto.UserModulePermissions = newUserModulePermissions;
                
                return Ok(updatedUserDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error updating user account!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("{userId}/permissions")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<UserModulePermissionDto>>> GetUserModulePermissions([FromRoute] string userId)
        {
            try
            {
                return Ok(await this._userService.GetUserModulePermissions(userId));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting user permissions!";
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