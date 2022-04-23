using System.ComponentModel.DataAnnotations;

using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models;

namespace Xyz.Api.Models
{
    public class CreateUserAccountDto
    {
        [Required]
        public RegistrationUserDto User { get; set; } = default!;

        [Required]
        public RegistrationProfileDto Profile { get; set; } = default!;

        public ICollection<UserPermission> UserPermissions { get; set; } = default!;

        public RegistrationUserAccount ToRegistrationUserAccount()
        {
            return new RegistrationUserAccount
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
                        FirstName = this.Profile.FirstName,
                        LastName = this.Profile.LastName
                    }
                },
                UserPermissions = this.UserPermissions,
                RawPassword = this.User.Password
            };
        }
    }
}
