using Xyz.Core.Entities.Identity;
using Xyz.Core.Models.Tenants;

namespace Xyz.Infrastructure.Seeds
{
    public static class ApplicationRolesSeed
    {
        public static ICollection<ApplicationRole> Get()
        {
            return new List<ApplicationRole>
            {
                new ApplicationRole 
                { 
                    Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac27"),
                    Name = Roles.ROOT, 
                    NormalizedName = Roles.ROOT 
                },
                new ApplicationRole 
                {
                    Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac28"), 
                    Name = Roles.ADMIN, 
                    NormalizedName = Roles.ADMIN
                },
                new ApplicationRole
                { 
                    Id = new Guid("0d27494f-c802-4804-8ea4-9fb5e6caac22"),
                    Name = Roles.USER, 
                    NormalizedName = Roles.USER
                }
            };
        }
    }
}