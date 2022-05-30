using System.ComponentModel.DataAnnotations;

using Xyz.Core.Dtos;
using Xyz.Core.Entities.Tenant;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Models;

namespace Xyz.Api.Models
{
    public class CreateUserAccountDto
    {
        [Required]
        public CreateUserDto User { get; set; } = default!;

        public ICollection<UserModulePermissionDto> UserModulePermissions { get; set; } = default!;

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
                    Profile = new Profile
                    {
                        FirstName = this.User.Profile.FirstName,
                        LastName = this.User.Profile.LastName
                    }
                },
                UserModulePermissions = this.UserModulePermissions
                    .Select(ump => new UserModulePermission
                    {
                        Id = ump.Id,
                        HasAccess = ump.HasAccess,
                        ModulePermissionId = ump.ModulePermissionId,
                        UserPermissions = ump.UserPermissions
                            .Select(up => new UserPermission
                            {
                                Id = up.Id,
                                CanCreate = up.CanCreate,
                                CanRead = up.CanRead,
                                CanUpdate = up.CanUpdate,
                                CanDelete = up.CanDelete,
                                PermissionId = up.PermissionId
                            })
                            .ToList()
                    })
                    .ToList(),
                RawPassword = this.User.Password
            };
        }
    }
}
