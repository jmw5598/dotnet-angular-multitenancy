import { Permission, UserPermission } from "@xyz/office/modules/core/entities";
import { UserPermissionGroup } from "@xyz/office/modules/core/models";

export const mapAssignablePermissionsToUserPermissionGroups = (permissions: Permission[]): UserPermissionGroup[] | null  => {
  return permissions
    .filter(permissions => !permissions.parentPermission)
    .map(permission => rootPermissionToUserPermissionGroup(permission, permissions));
}

export const  rootPermissionToUserPermissionGroup = (permission: Permission, permissions: Permission[]): UserPermissionGroup => {
  const childUserPermissions = permissions.filter(p => p?.parentPermission?.id === permission.id)
    .map(p => permissionToUserPermission(p));
  
  const rootUserPermission = permissionToUserPermission(permission);
  rootUserPermission.childUserPermissions = childUserPermissions;

  return userPermissionToUserPermissionGroup(rootUserPermission);
}

export const permissionToUserPermission = (permission: Permission): UserPermission => {
  return {
    permission: permission,
    canCreate: false,
    canRead: false,
    canUpdate: false,
    canDelete: false
  } as UserPermission
}

export const userPermissionToUserPermissionGroup = (userPermission: UserPermission): UserPermissionGroup => {
  return {
    hasAccess: false,
    userPermission: userPermission
  } as UserPermissionGroup;
}

// @NOTE - this only handle singel tier nesting of user permissions, will
//         have to refactor usign recursion to handle infinite userPermission nesting.
export const flattenUserPermissionGroups = (userPermissionGroups: UserPermissionGroup[]): UserPermission[] => {
  const rootUserPermissions: UserPermission[] = userPermissionGroups.map(group => group.userPermission);

  const flattenedUserPermissions: UserPermission[] = [];

  for (let i = 0; i < rootUserPermissions?.length; i++) {
    const parentUserPermision: UserPermission = { 
      ...rootUserPermissions[i], 
      childUserPermissions: undefined 
    } as UserPermission;

    flattenedUserPermissions.push(parentUserPermision);

    rootUserPermissions[i]?.childUserPermissions?.forEach(up => {
      up.parentUserPermission = parentUserPermision;
      flattenedUserPermissions.push(up);
    });
  }

  return flattenedUserPermissions;
}
