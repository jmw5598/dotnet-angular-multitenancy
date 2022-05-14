import { ModulePermission, Permission, UserModulePermission, UserPermission } from "@xyz/office/modules/core/entities";

export const mapAssignableModulePermissionsToUserModulePermissions = (modulePermissions: ModulePermission[]): UserModulePermission[] => {
  return modulePermissions
    .map(modulePermission => modulePermissionToUserModulePermission(modulePermission));
}

export const modulePermissionToUserModulePermission = (modulePermission: ModulePermission): UserModulePermission => {
  return {
    hasAccess: false,
    modulePermission: {
      ...modulePermission
    },
    userPermissions: [
      ...modulePermission?.permissions?.map(permission => permissionToUserPermission(permission)) || []
    ] as UserPermission[]
  } as UserModulePermission;
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
