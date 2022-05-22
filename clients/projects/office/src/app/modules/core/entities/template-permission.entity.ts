import { BaseTemplatePermission } from "./base-template-permission.entity";
import { TemplateModulePermission } from "./template-module-permission.entity";

export interface TemplatePermissions extends BaseTemplatePermission {
  templateModulePermissionId: string,
  tempalteModulePermission?: TemplateModulePermission
}
