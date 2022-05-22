import { BaseTemplateModulePermission } from "./base-template-module-permission.entity";
import { UserPermission } from "./user-permission.entity";

export interface UserModulePermission extends BaseTemplateModulePermission {
  aspNetUserId: string,
  userPermissions?: UserPermission[],
}
