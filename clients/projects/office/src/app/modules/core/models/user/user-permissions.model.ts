import { UserModulePermission } from "../../entities";
import { UserPermission } from "../../entities/user-permission.entity";

export enum ModulePermissionNames {
  ADMINISTRATION_MODULE = 'Administration Module',
  DASHBOARD_MODULE = 'Dashboard Module',
  INVENTORY_MODULE = 'Inventroy Module',
  SECURITY_MODULE = 'Security Module',
  SERVICE_MODULE = 'Service Module',
}

export enum PermissionNames {
  DASHBOARD_OVERVIEW = 'Dashboard Overview',
  USER_ACCOUNTS = 'User Accounts',
  SECURITY_GENERAL = 'Security General',
  SECURITY_PERMISSIONS = 'Security Permissions',
  SETTINGS = 'Settings',
  ACCOUNT_DETAILS = 'Account Details'
}

export type UserModulePermissionsMap = {
  [key in ModulePermissionNames]: UserModulePermission
}

export type UserPermissionsMap = {
  [key in PermissionNames]: UserPermission
}

export interface UserModulesAndPermissionsMap {
  modules: UserModulePermissionsMap,
  permissions: UserPermissionsMap
}

export interface UserModulePermissions {
  modules: UserModulePermission[]
}
