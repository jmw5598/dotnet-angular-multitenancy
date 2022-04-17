import { UserPermission } from "../../entities/user-permission.entity";

export enum ModulePermissionType {
  Dashboard = 'dashboard',
  DashboardOverview = 'dashboardOverview',
  Service = 'service',
  Inventory = 'inventroy',
  Settings = 'settings',
  UserAccounts = 'userAccounts'
}

export interface UserPermissions {
  permission: UserPermission
}

export type UserPermissionsMap = { [key: string]: UserPermission };

export interface UserPermissionGroup {
  userPermission: UserPermission;
  hasAccess: boolean
}
