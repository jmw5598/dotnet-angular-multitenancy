using Xyz.Core.Entities.Tenant;

namespace Xyz.Infrastructure.Seeds
{
    public static class ModulePermissionsAndPermissionsSeed
    {
        public class ModulerPermissionsAndPermissions
        {
            public ICollection<ModulePermission> ModulePermissions { get; set; } = default!;
            public ICollection<Permission> Permissions { get; set; } = default!;
        }
        public static ModulerPermissionsAndPermissions Get()
        {
            // AdministrationModule Module
            var administrationModulePermission = new ModulePermission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc27"),
                Name = "Administration Module",
            };

            var settingsPermissions = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc22"),
                Name = "Settings",
                ModulePermissionId = administrationModulePermission.Id

            };

            var userAccountsPermission = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc21"),
                Name = "User Accounts",
                ModulePermissionId = administrationModulePermission.Id
            };

            var accountDetailsPermission = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc44"),
                Name = "Account Details",
                ModulePermissionId = administrationModulePermission.Id
            };

            // Dashboard Module
            var dashboardModulePermission = new ModulePermission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc17"),
                Name = "Dashboard Module"
            };

            var dashboardOverviewPermission = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc07"),
                Name = "Dashboard Overview",
                ModulePermissionId = dashboardModulePermission.Id
            };

            // Security Module
            var securityModulePermission = new ModulePermission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc16"),
                Name = "Security Module",
            };

            var securityGeneralPermission = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacc11"),
                Name = "Security General",
                ModulePermissionId = securityModulePermission.Id
            };

            var securityPermissionsPermission = new Permission
            {
                Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6cacd27"),
                Name = "Security Permissions",
                ModulePermissionId = securityModulePermission.Id
            };

            return new ModulerPermissionsAndPermissions
            {
                ModulePermissions = new List<ModulePermission>
                {
                    securityModulePermission,
                    administrationModulePermission,
                    dashboardModulePermission
                },
                Permissions = new List<Permission>
                {
                    securityGeneralPermission,
                    securityPermissionsPermission,
                    dashboardOverviewPermission,
                    settingsPermissions,
                    userAccountsPermission,
                    accountDetailsPermission
                }
            };
        }
    }
}