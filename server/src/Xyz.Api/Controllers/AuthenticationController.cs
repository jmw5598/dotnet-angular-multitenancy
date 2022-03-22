using Microsoft.AspNetCore.Mvc;

using Xyz.Core.Interfaces;

namespace Xyz.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogger<AuthenticationController> _logger;
        private IAuthenticationService _authenticationService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            this._logger = logger;
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<object> Login()
        {
            try
            {
                return this._authenticationService.Login();
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<object> Register()
        {
            try
            {
                return this._authenticationService.Register();
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<object> ForgotPassword()
        {
            try
            {
                return this._authenticationService.ForgotPassword();
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
                return this._authenticationService.ChangePassword();
            }
            catch (Exception e)
            {
                this._logger.LogError($"There was an error, {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
}