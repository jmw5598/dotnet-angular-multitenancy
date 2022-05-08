using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Tenant;

namespace Xyz.Infrastructure.Extensions
{
    public static class InfrastructureModelBuilderExtensions
    {
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            var settingsModulePermissions = new ModulePermission
            {
                Id = Guid.NewGuid(),
                Name = "Settings Module"
            };

            // 
            var userAccountsModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "User Accounts Module",
                ModulePermissionId = settingsModulePermissions.Id
            };

            var dashboardModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Dashboard Module"
            };

            var dashboardOverviewModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Dashboard Overview Module",
                ModulePermissionId = dashboardModulePermission.Id
            };

            modelBuilder.Entity<ModulePermission>().HasData(
                settingsModulePermissions,
                dashboardModulePermission
            );

            modelBuilder.Entity<Permission>().HasData(
                userAccountsModulePermission,
                dashboardOverviewModulePermission
            );
        }
    }
}