import { ModulePermissionNames, PermissionNames } from "../user/user-permissions.model";

export interface NavigationLink {
  label: string,
  icon?: string,
  routerLink?: string | string[],
  children?: NavigationLink[],
  requiredModulePermissionName?: ModulePermissionNames | null,
  requiredPermissionName?: PermissionNames | null
}
