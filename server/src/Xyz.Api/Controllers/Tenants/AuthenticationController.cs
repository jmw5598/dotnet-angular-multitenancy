using Microsoft.AspNetCore.Mvc;

using Xyz.Api.Models;
using Xyz.Core.Models;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Models.Tenants;
using Xyz.Core.Interfaces.Tenants;
using Xyz.Core.Dtos.Multitenancy;

namespace Xyz.Api.Controllers.Tenants
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

                var authenticatedUser = await this._authenticationService.LoginAsync(credentials);

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

        [HttpPost("forgot-password")]
        public async Task<object> ForgotPassword()
        {
            try
            {
                return await this._authenticationService.ForgotPasswordAsync();
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
                return await this._authenticationService.ChangePasswordAsync();
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
                return Ok(await this._authenticationService.RefreshAccessTokenAsync(refreshTokenRequest));
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
}
