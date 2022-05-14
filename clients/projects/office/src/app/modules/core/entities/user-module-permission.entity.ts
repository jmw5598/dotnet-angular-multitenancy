import { ModulePermission } from "./module-permission.entity";
import { UserPermission } from "./user-permission.entity";

export interface UserModulePermission {
  id: string,
  hasAccess: boolean,
  modulePermissionId: string,
  aspNetUserId: string,
  modulePermission?: ModulePermission,
  userPermissions?: UserPermission[],
}
