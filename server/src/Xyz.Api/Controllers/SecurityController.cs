using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IEnumerable<TemplateModulePermissionName>>> GetTemplateModulePermissions()
        {
            try
            {
                return Ok(new List<TemplateModulePermissionName>{});
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
                var templateModulePermissionName = createModulePermissionNameDto.ToTemplateModulePermissionName();
                return Ok(
                    await this._permissionsService
                        .SaveTemplateModulePermissionName(templateModulePermissionName)
                );
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating ecurity permissions template!";
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

        [HttpGet("permissions/templates/:templateId")]
        public async Task<ActionResult<TemplateModulePermissionName>> GetTemplateModulePermissionById()
        {
            try
            {
                // @TODO get tempalte permission name with all module permissions
                return Ok(new TemplateModulePermissionName{});
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting available security permissions!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                return BadRequest(errorMessage);
            }
        }
    }
}
