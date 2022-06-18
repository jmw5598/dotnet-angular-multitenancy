using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Xyz.Core.Entities.Identity;
using Xyz.Core.Entities.Tenants;
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

        public static void HandleCustomIdentityTableMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.ToTable("asp_net_user_roles");
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });

            modelBuilder.Entity<ApplicationUser>(user => 
            {
                user.ToTable("asp_net_users");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims");
            modelBuilder.Entity<ApplicationRole>().ToTable("asp_net_roles");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            var seedRoles = ApplicationRolesSeed.Get();
            modelBuilder.Entity<ApplicationRole>().HasData(seedRoles);
        }
    }
}