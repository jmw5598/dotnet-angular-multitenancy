import { UserPermission } from "../../entities/user-permission.entity";

export enum ModulePermissionType {
  ACCOUNTS = 'accounts'
}

export interface UserPermissions {
  permission: UserPermission
}

export type UserPermissionsMap = { [key: string]: UserPermission };