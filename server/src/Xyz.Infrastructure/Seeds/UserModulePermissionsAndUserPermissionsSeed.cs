using Xyz.Core.Entities.Tenants;

namespace Xyz.Infrastructure.Seeds
{
    public class UserModulePermissionAndUserPermisisons
    {
        public ICollection<UserModulePermission> UserModulePermissions { get; set; } = default!;
        public ICollection<UserPermission> UserPermissions { get; set; } = default!;
    }

    public static class UserModulePermissionsAndUserPermissionsSeed
    {
        public static UserModulePermissionAndUserPermisisons Get(string userId)
        {
            var modulePermissionsAndPermissions = ModulePermissionsAndPermissionsSeed.Get();

            var userPermissions = new List<UserPermission> { };

            var userModulePermissions = modulePermissionsAndPermissions.ModulePermissions
                .Select(mp => {
                    var ump = new UserModulePermission
                    {
                        Id = Guid.NewGuid(),
                        HasAccess = true,
                        ModulePermissionId = mp.Id,
                        UserId = new Guid(userId)
                    };

                    userPermissions.AddRange(
                        modulePermissionsAndPermissions.Permissions
                            .Where(p => p.ModulePermissionId.ToString() == mp.Id.ToString())
                            .Select(p => 
                                new UserPermission
                                {
                                    Id = Guid.NewGuid(),
                                    CanCreate = true,
                                    CanRead = true,
                                    CanUpdate = true,
                                    CanDelete = true,
                                    PermissionId = p.Id,
                                    UserModulePermissionId = ump.Id
                                }));
                    return ump;
                }).ToList();

            return new UserModulePermissionAndUserPermisisons
            {
                UserModulePermissions = userModulePermissions,
                UserPermissions = userPermissions
            };
        }
    }
}