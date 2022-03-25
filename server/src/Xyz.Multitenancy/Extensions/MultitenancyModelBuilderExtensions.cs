using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Xyz.Core.Models;

namespace Xyz.Multitenancy.Extensions
{
    public static class MultitenancyModelBuilderExtensions
    {
        public static void SeedIdentityRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = Roles.ADMIN, NormalizedName = Roles.ADMIN },
                new IdentityRole { Name = Roles.USER, NormalizedName = Roles.USER }
            );
        }
    }
}