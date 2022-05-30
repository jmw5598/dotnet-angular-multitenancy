using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Tenant;
using Xyz.Infrastructure.Seeds;

namespace Xyz.Infrastructure.Extensions
{
    public static class InfrastructureModelBuilderExtensions
    {
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            var modulePermissionsAndPermission = ModulePermissionsAndPermissionsSeed.Get();

            modelBuilder.Entity<ModulePermission>().HasData(
                modulePermissionsAndPermission.ModulePermissions
            );

            modelBuilder.Entity<Permission>().HasData(
                modulePermissionsAndPermission.Permissions
            );
        }
    }
}