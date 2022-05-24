import { ModulePermission, Permission, TemplateModulePermission } from "@xyz/office/modules/core/entities";
import { TemplatePermission } from "@xyz/office/modules/core/entities/template-permission.entity";

export const mapAssignableModulePermissionsToTemplateModulePermissions = (modulePermissions: ModulePermission[]): TemplateModulePermission[] => {
  return modulePermissions
    .map(modulePermission => modulePermissionToTemplateModulePermission(modulePermission));
}

export const modulePermissionToTemplateModulePermission = (modulePermission: ModulePermission): TemplateModulePermission => {
  return {
    hasAccess: false,
    modulePermission: {
      ...modulePermission
    },
    templatePermissions: [
      ...modulePermission?.permissions?.map(permission => permissionToTemplatePermission(permission)) || []
    ] as TemplatePermission[]
  } as TemplateModulePermission;
}

export const permissionToTemplatePermission = (permission: Permission): TemplatePermission => {
  return {
    permission: permission,
    canCreate: false,
    canRead: false,
    canUpdate: false,
    canDelete: false
  } as TemplatePermission
}
