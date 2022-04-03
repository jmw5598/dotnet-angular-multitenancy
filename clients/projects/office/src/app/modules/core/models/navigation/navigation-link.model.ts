import { ModulePermissionType } from "../user/user-permissions.model";

export interface NavigationLink {
  label: string,
  icon?: string,
  routerLink?: string | string[],
  children?: NavigationLink[],
  requireModulePermissionType: ModulePermissionType | null
}
