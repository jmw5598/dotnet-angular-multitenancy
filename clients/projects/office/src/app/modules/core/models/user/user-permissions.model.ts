import { UserPermission } from "../../entities/user-permission.entity";

export enum PermissionType {
  ACCOUNTS = 'accounts'
}

export interface UserPermissions {
  permission: UserPermission
}
