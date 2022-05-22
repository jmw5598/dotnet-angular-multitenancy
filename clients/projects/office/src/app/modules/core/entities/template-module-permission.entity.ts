import { BaseTemplateModulePermission } from "./base-template-module-permission.entity";
import { TemplateModulePermissionName } from "./template-module-permission-name.entity";

export interface TemplateModulePermission extends BaseTemplateModulePermission {
  templateModulePermissionNameId: string,
  templateModulePermissionName?: TemplateModulePermissionName
}
