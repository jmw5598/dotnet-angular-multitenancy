using System.ComponentModel.DataAnnotations;

using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Api.Models
{
    public class CreateUserAccountDto
    {
        [Required]
        public RegistrationUserAccountDto User { get; set; } = default!;

        public ICollection<UserModulePermission> UserModulePermissions { get; set; } = default!;

        public UserAccount ToUserAccount()
        {
            return new UserAccount
            {
                User = new ApplicationUser
                {
                    UserName = this.User.UserName,
                    NormalizedUserName = this.User.UserName.ToUpper(),
                    Email = this.User.UserName,
                    NormalizedEmail = this.User.UserName.ToUpper(),
                    EmailConfirmed = true,
                    Tenants = new List<Tenant>(),
                    Profile = new Profile
                    {
                        FirstName = this.User.Profile.FirstName,
                        LastName = this.User.Profile.LastName
                    }
                },
                UserModulePermissions = this.UserModulePermissions,
                RawPassword = this.User.Password
            };
        }
    }
}
