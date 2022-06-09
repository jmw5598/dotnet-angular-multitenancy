using Microsoft.AspNetCore.Mvc;

using Xyz.Api.Models;
using Xyz.Core.Models;
using Xyz.Core.Interfaces;
using Xyz.Core.Dtos;

namespace Xyz.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthenticationService authenticationService)
        {
            this._logger = logger;
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticatedUser>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var credentials = new Credentials
                {
                    UserName = loginRequestDto.UserName,
                    Password = loginRequestDto.Password
                };

                var authenticatedUser = await this._authenticationService.Login(credentials);

                if (authenticatedUser == null)
                {
                    return Unauthorized(
                        new ResponseMessage
                        {
                            Status = ResponseStatus.ERROR,
                            Message = "Invalid username/password!"
                        }
                    );
                }

                return Ok(authenticatedUser);
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = e.Message
                    }
                );
            }
        }

        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegistrationDto registrationDto)
        {
            try
            {
                return Ok(
                    await this._authenticationService.Register(registrationDto.ToRegistration())
                );
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(
                    new ResponseMessage
                    {
                        Status = ResponseStatus.ERROR,
                        Message = e.Message
                    }
                );
            }
        }

        [HttpPost("forgot-password")]
        public async Task<object> ForgotPassword()
        {
            try
            {
                return await this._authenticationService.ForgotPassword();
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpPost("change-password")]
        public async Task<object> ChangePassword()
        {
            try
            {
                return await this._authenticationService.ChangePassword();
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpPost("token/refresh")]
        public async Task<ActionResult<AuthenticatedUser>> RefreshAccessToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            try
            {
                return Ok(await this._authenticationService.RefreshAccessToken(refreshTokenRequest));
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("companies/search")]
        public async Task<ActionResult<Page<TenantDto>>> SearchCompanies(
            [FromQuery] string? query = null,
            [FromQuery] string column = "id",
            [FromQuery] SortDirection direction = SortDirection.Ascend,
            [FromQuery] int index = 0,
            [FromQuery] int size = 10)
        {
            var filter = new BasicQuerySearchFilter { Query = query };
            var pageRequest = new PageRequest { 
                Index = index, 
                Size = size,
                Sort = new Sort { Column = column, Direction = direction }    
            };
            try
            {
                return Ok(await this._authenticationService.SearchCompanies(filter, pageRequest));
            }
            catch (Exception e)
            {
                var errorMessage = "Error searching companies!";
                this._logger.LogError(errorMessage, new { Exception = e });
                return BadRequest(errorMessage);
            }
        }
    }
}
