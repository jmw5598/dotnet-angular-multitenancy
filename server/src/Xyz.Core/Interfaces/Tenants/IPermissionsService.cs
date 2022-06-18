using Xyz.Core.Entities.Tenants;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Dtos;

namespace Xyz.Core.Interfaces.Tenants
{
    public interface IPermissionsService
    {
        Task<IEnumerable<Permission>> FindAllAsync();
        Task<IEnumerable<ModulePermission>> FindAllModulePermissionsAsync();
        Task<IEnumerable<TemplateModulePermissionNameDto>> FindAllTemplateModulePermissionNamesAsync();
        Task<Page<TemplateModulePermissionNameDto>> SearchTemplateModulePermissionNamesAsync(PageRequest pageRequest, BasicQuerySearchFilter filter);
        Task<TemplateModulePermissionNameDto> SaveTemplateModulePermissionNameAsync(TemplateModulePermissionName template);
        Task<TemplateModulePermissionNameDto> FindTemplateModulePermissionNameByIdAsync(string templateModulePermissionNameId);
        Task<TemplateModulePermissionNameDto> DeleteTemplateModulerPermissionNameByIdAsync(string templateModulePermissionNameId);
        Task<TemplateModulePermissionNameDto> UpdateTemplateModulePermissionNameAsync(string templateModulePermissionNameId, TemplateModulePermissionName template);
    }
}
