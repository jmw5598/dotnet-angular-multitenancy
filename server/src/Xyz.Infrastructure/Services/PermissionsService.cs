using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Data;


using Xyz.Core.Interfaces;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;
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

        public async Task<IEnumerable<Permission>> FindAll()
        {
            return await this._context.Permissions
                .Select(p => p)
                .ToListAsync();
        }

        public async Task<IEnumerable<ModulePermission>> FindAllModulePermissions()
        {
            return await this._context.ModulePermissions
                .Include(m => m.Permissions.OrderBy(p => p.Name))
                .Select(mp => mp)
                .OrderBy(mp => mp.Name)
                .ToListAsync();
        }

        public async Task<Page<TemplateModulePermissionNameDto>> SearchTemplateModulePermissionNames(PageRequest pageRequest, BasicQuerySearchFilter filter)
        {
            try
            {
                IQueryable<TemplateModulePermissionName> query = this._context.TemplateModulePermissionNames;
                
                if (filter?.Query != null)
                {
                    var queryTerm = filter.Query.Trim().ToLower();
                    query = query.Where(template => 
                        template.Name.ToLower().Contains(queryTerm)
                            || template.Description.ToLower().Contains(queryTerm));
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
    }
}