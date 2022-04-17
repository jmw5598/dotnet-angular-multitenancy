using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;

namespace Xyz.Infrastructure.Extensions
{
    public static class InfrastructureModelBuilderExtensions
    {
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            var settingsModulePermissions = new Permission
            {
                Id = Guid.NewGuid(),
                Type = ModulePermissionType.Settings,
                Name = "Settings Module"
            };

            var userAccountsModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Type = ModulePermissionType.UserAccounts,
                Name = "User Accounts Module",
                ParentPermissionId = settingsModulePermissions.Id
            };

            var dashboardModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Type = ModulePermissionType.Dashboard,
                Name = "Dashboard Module"
            };

            var dashboardOverviewModulePermission = new Permission
            {
                Id = Guid.NewGuid(),
                Type = ModulePermissionType.DashboardOverview,
                Name = "Dashboard Overview Module",
                ParentPermissionId = dashboardModulePermission.Id
            };

            modelBuilder.Entity<Permission>().HasData(
                settingsModulePermissions, 
                userAccountsModulePermission,
                dashboardModulePermission,
                dashboardOverviewModulePermission
            );
        }
    }
}