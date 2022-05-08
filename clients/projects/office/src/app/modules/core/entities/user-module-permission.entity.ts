import { ModulePermission } from "./module-permission.entity";
import { UserPermission } from "./user-permission.entity";

export interface UserModulePermission {
  id: string,
  hasAccess: boolean,
  modulePermissionId: string,
  modulePermission?: ModulePermission,
  userPermissions?: UserPermission[],
}
