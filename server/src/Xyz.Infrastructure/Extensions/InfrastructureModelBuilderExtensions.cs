using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Tenant;

namespace Xyz.Infrastructure.Extensions
{
    public static class InfrastructureModelBuilderExtensions
    {
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            // AdministrationModule Module
            var administrationModulePermission = new ModulePermission
            {
                Id = Guid.NewGuid(),
                Name = "Administration Module",
            };

            var settingsPermissions = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Settings",
                ModulePermissionId = administrationModulePermission.Id

            };

            var userAccountsPermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "User Accounts",
                ModulePermissionId = administrationModulePermission.Id
            };

            // Dashboard Module
            var dashboardModulePermission = new ModulePermission
            {
                Id = Guid.NewGuid(),
                Name = "Dashboard Module"
            };

            var dashboardOverviewPermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Dashboard Overview",
                ModulePermissionId = dashboardModulePermission.Id
            };

            // Security Module
            var securityModulePermission = new ModulePermission
            {
                Id = Guid.NewGuid(),
                Name = "Security Module",
            };

            var securityGeneralPermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Security General",
                ModulePermissionId = securityModulePermission.Id
            };

            var securityPermissionsPermission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = "Security Permissions",
                ModulePermissionId = securityModulePermission.Id
            };

            modelBuilder.Entity<ModulePermission>().HasData(
                administrationModulePermission,
                dashboardModulePermission,
                securityModulePermission
            );

            modelBuilder.Entity<Permission>().HasData(
                settingsPermissions,
                userAccountsPermission,
                dashboardOverviewPermission,
                securityGeneralPermission,
                securityPermissionsPermission
            );
        }
    }
}