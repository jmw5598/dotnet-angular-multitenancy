using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;

using Xyz.Core.Dtos;
using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Security;

using Xyz.Api.Models;

namespace Xyz.Api.Controllers
{
    [Authorize(Policy = PolicyNames.RequireTenant)]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ILogger<SecurityController> _logger;
        private IPermissionsService _permissionsService;
        private ITenantAccessor<Tenant> _tenantAccessor;

        public SecurityController(
            ILogger<SecurityController> logger,
            IPermissionsService permissionsService,
            ITenantAccessor<Tenant> tenantAccessor)
        {
            this._logger = logger;
            this._permissionsService = permissionsService;
            this._tenantAccessor = tenantAccessor;
        }

        [HttpGet("permissions/available")]
        public async Task<ActionResult<IEnumerable<ModulePermission>>> GetAvailableUserModulePermissions()
        {
            try
            {
                return Ok(await this._permissionsService.FindAllModulePermissions());
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting available security permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions/templates")]
        public async Task<ActionResult<IEnumerable<TemplateModulePermissionNameDto>>> GetTemplateModulePermissions()
        {
            try
            {
                return Ok(await this._permissionsService.FindAllTemplateModulePermissionNames());
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting security permission templates!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpPost("permissions/templates")]
        public async Task<ActionResult<TemplateModulePermissionNameDto>> CreateTemplateModulePermissions(
            [FromBody] CreateTemplateModulePermissionNameDto createModulePermissionNameDto)
        {
            try
            {
                string? userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var templateModulePermissionName = createModulePermissionNameDto.ToTemplateModulePermissionName();
                templateModulePermissionName.CreatedById = new Guid(userId);
                templateModulePermissionName.UpdatedById = new Guid(userId);
                
                return Ok(
                    await this._permissionsService
                        .SaveTemplateModulePermissionName(templateModulePermissionName)
                );
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating security permissions template!";
                this._logger.LogError(ex?.InnerException?.Message, ex);
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions/templates/search")]
        public async Task<ActionResult<IEnumerable<TemplateModulePermissionName>>> SearchTemplateModulePermissions(
            [FromQuery] string? query = null,
            [FromQuery] int index = 0,
            [FromQuery] int size = 20)
        {
            var pageRequest = new PageRequest { Index = index, Size = size };
            var querySearchFilter = new BasicQuerySearchFilter { Query = query };

            try
            {
                return Ok(
                    await this._permissionsService
                        .SearchTemplateModulePermissionNames(pageRequest, querySearchFilter)
                );
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching security permission templates!";
                this._logger.LogError(errorMessage, new { Exception = ex, PageRequest = pageRequest, Filter = querySearchFilter });
                return BadRequest(errorMessage);
            }
        }

        [HttpGet("permissions/templates/{templateModulePermissionNameId}")]
        public async Task<ActionResult<TemplateModulePermissionNameDto>> GetTemplateModulePermissionById(
            [FromRoute()] string templateModulePermissionNameId)
        {
            try
            {
                return Ok(await this._permissionsService
                    .FindTemplateModulePermissionNameById(templateModulePermissionNameId)
                );
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting available security permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpPut("permissions/templates/{templateModulePermissionNameId}")]
        public async Task<ActionResult<TemplateModulePermissionNameDto>> UpdateTemplateModulePermissions(
            [FromRoute] string templateModulePermissionNameId,
            [FromBody] CreateTemplateModulePermissionNameDto createModulePermissionNameDto)
        {
            try
            {
                string? userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var templateModulePermissionName = createModulePermissionNameDto.ToTemplateModulePermissionName();
                templateModulePermissionName.UpdatedById = new Guid(userId);

                return Ok(await this._permissionsService
                    .UpdateTemplateModulePermissionName(templateModulePermissionNameId, templateModulePermissionName));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error update security permissions template!";
                this._logger.LogError(ex?.InnerException?.Message, ex);
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete("permissions/templates/{templateModulePermissionNameId}")]
        public async Task<ActionResult<TemplateModulePermissionNameDto>> DeleteTemplateModulePermissions(
            [FromRoute] string templateModulePermissionNameId)
        {
            try
            {
                return Ok(await this._permissionsService
                    .DeleteTemplateModulerPermissionNameById(templateModulePermissionNameId));
            }
            catch (Exception ex)
            {
                var errorMessage = "Error deleting security permissions template!";
                this._logger.LogError(ex?.InnerException?.Message, ex);
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }
    }
}
