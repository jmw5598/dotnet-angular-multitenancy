using Microsoft.EntityFrameworkCore;

using Xyz.Core.Entities.Tenant;
using Xyz.Core.Models;

namespace Xyz.Infrastructure.Extensions
{
    public static class InfrastructureModelBuilderExtensions
    {
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Permission>().HasData(
               new Permission
               {
                   Id = Guid.NewGuid(),
                   Type = PermissionType.ACCOUNTS,
                   Name = "Accounts Module"
               }
           );
        }
    }
}