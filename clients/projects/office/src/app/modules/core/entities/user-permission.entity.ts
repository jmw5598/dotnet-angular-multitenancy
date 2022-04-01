import { UserPermissionType } from "../models";

export interface UserPermission {
  id: string,
  type: UserPermissionType,
  canCreate: boolean,
  canRead: boolean,
  canUpdate: boolean,
  canDelete: boolean
}
