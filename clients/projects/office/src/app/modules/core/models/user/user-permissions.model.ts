import { UserModulePermission } from "../../entities";
import { UserPermission } from "../../entities/user-permission.entity";

export enum ModulePermissionType {
  Dashboard = 'dashboard',
  DashboardOverview = 'dashboardOverview',
  Service = 'service',
  Inventory = 'inventroy',
  Settings = 'settings',
  UserAccounts = 'userAccounts'
}

export enum ModulePermissionNames {
  DASHBOARD_MODULE = 'Dashboard Module',
  SETTINGS_MODULE = 'Settings Module',
  SERVICE_MODULE = 'Service Module',
  INVENTORY_MODULE = 'Inventroy Module',
}

export enum PermissionNames {
  DASHBOARD_OVERVIEW_MODULE = 'Dashboard Overview Module',
  USER_ACCOUNTS_MODULE = 'User Accounts Module'
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
