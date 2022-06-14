using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;

using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models.Paging;
using Xyz.Core.Models.SearchFilters;
using Xyz.Core.Dtos;
using Xyz.Infrastructure.Data;

namespace Xyz.Infrastructure.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly ILogger<PlansService> _logger;
        private readonly ApplicationDbContext _context;

        public PermissionsService(ILogger<PlansService> logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<IEnumerable<Permission>> FindAllAsync()
        {
            return await this._context.Permissions
                .Select(p => p)
                .ToListAsync();
        }

        public async Task<IEnumerable<ModulePermission>> FindAllModulePermissionsAsync()
        {
            return await this._context.ModulePermissions
                .Include(m => m.Permissions.OrderBy(p => p.Name))
                .Select(mp => mp)
                .OrderBy(mp => mp.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<TemplateModulePermissionNameDto>> FindAllTemplateModulePermissionNamesAsync()
        {
            try
            {
                return await this._context.TemplateModulePermissionNames
                    .OrderBy(template => template.Name)
                    .Select(template => template.ToDto())
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting all permission templates!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<Page<TemplateModulePermissionNameDto>> SearchTemplateModulePermissionNamesAsync(PageRequest pageRequest, BasicQuerySearchFilter filter)
        {
            try
            {
                IQueryable<TemplateModulePermissionName> query = this._context.TemplateModulePermissionNames
                    .Include(t => t.CreatedBy)
                    .Include(t => t.UpdatedBy);
                
                if (filter?.Query != null)
                {
                    var queryTerm = filter.Query.Trim().ToLower();
                    query = query.Where(template => 
                        template.Name.ToLower().Contains(queryTerm)
                            || template.Description.ToLower().Contains(queryTerm));
                }

                if (pageRequest.Sort != null)
                {
                    switch (pageRequest.Sort.Column)
                    {
                        case "description":
                            query = pageRequest.Sort.Direction == SortDirection.Ascend
                                ? query.OrderBy(t => t.Description)
                                : query.OrderByDescending(t => t.Description);
                            break;
                        case "name":
                            query = pageRequest.Sort.Direction == SortDirection.Ascend
                                ? query.OrderBy(t => t.Name)
                                : query.OrderByDescending(t => t.Name);
                            break;
                        case "id":
                        default:
                            query = pageRequest.Sort.Direction == SortDirection.Ascend 
                                ? query.OrderBy(t => t.Id)
                                : query.OrderByDescending(t => t.Id);
                            break;
                    }
                }
                    
                var templatesSource = query.Select(template => template.ToDto());

                return await Page<TemplateModulePermissionNameDto>.From(templatesSource, pageRequest);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error searching permissions templates!";
                this._logger.LogError(errorMessage, new { Exception = ex });
                throw;
            }
        }

        public async Task<TemplateModulePermissionNameDto> SaveTemplateModulePermissionNameAsync(TemplateModulePermissionName template)
        {
            try
            {
                this._context.TemplateModulePermissionNames.Add(template);
                await this._context.SaveChangesAsync();
                return template.ToDto();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating permissions template!";
                this._logger.LogError(errorMessage, new { Exception = ex, TemplateModulePermissionName = template });
                throw;
            }
        }

        public async Task<TemplateModulePermissionNameDto> FindTemplateModulePermissionNameByIdAsync(string templateModulePermissionNameId)
        {
            try
            {
                var template = await this._context.TemplateModulePermissionNames
                    .Include(tmpn => tmpn.TemplateModulePermissions)
                    .ThenInclude(tmp => tmp.TemplatePermissions)
                    .ThenInclude(tp => tp.Permission)
                    .Include(tmpn => tmpn.TemplateModulePermissions)
                    .ThenInclude(tmp => tmp.ModulePermission)
                    .Where(tmpn => tmpn.Id.ToString() == templateModulePermissionNameId)
                    .FirstOrDefaultAsync();

                if (template == null)
                {
                    throw new Exception("Permission template with the giveng ID was not found!");
                }

                return template.ToDto();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error getting permissions template by ID!";
                this._logger.LogError(errorMessage, new { 
                    Exception = ex, 
                    TemplateModulePermissionNameId = templateModulePermissionNameId
                });
                throw;
            }
        }

        public async Task<TemplateModulePermissionNameDto> DeleteTemplateModulerPermissionNameByIdAsync(string templateModulePermissionNameId)
        {
            try
            {
                var template = await this._context.TemplateModulePermissionNames
                    .Where(tmpn => tmpn.Id.ToString() == templateModulePermissionNameId)
                    .FirstOrDefaultAsync();

                if (template == null)
                {
                    throw new Exception("Permission template with the giveng ID was not found!");
                }

                this._context.Remove(template);
                this._context.SaveChanges();

                return template.ToDto();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error deleting permissions template by ID!";
                this._logger.LogError(errorMessage, new { 
                    Exception = ex, 
                    TemplateModulePermissionNameId = templateModulePermissionNameId
                });
                throw;
            }
        }

        public async Task<TemplateModulePermissionNameDto> UpdateTemplateModulePermissionNameAsync(string templateModulePermissionNameId, TemplateModulePermissionName template)
        {
            try
            {
                var existingTemplateModulerPermissionName = await this._context.TemplateModulePermissionNames
                    .Where(tmpn => tmpn.Id.ToString() == templateModulePermissionNameId)
                    .FirstOrDefaultAsync();

                if (existingTemplateModulerPermissionName == null)
                {
                    throw new Exception("Permission template with the giveng ID was not found!");
                }

                template.CreatedOn = existingTemplateModulerPermissionName.CreatedOn;
                template.CreatedById = existingTemplateModulerPermissionName.CreatedById;
                template.UpdatedOn = DateTime.UtcNow;

                // @TODO(jason) This should update the template instead of delete and insert
                // Will keep this for now but this should reassessed.
                this._context.TemplateModulePermissionNames.Remove(existingTemplateModulerPermissionName);
                this._context.SaveChanges();

                this._context.TemplateModulePermissionNames.Add(template);
                this._context.SaveChanges();

                return template.ToDto();
            }
            catch (Exception ex)
            {
                var errorMessage = "Error updating permissions template by ID!";
                this._logger.LogError(errorMessage, new { 
                    Exception = ex, 
                    TemplateModulePermissionNameId = templateModulePermissionNameId
                });
                throw;
            }
        }
    }
}