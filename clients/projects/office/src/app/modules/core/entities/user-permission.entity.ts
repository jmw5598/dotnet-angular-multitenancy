import { Permission } from './permission.entity';

export interface UserPermission {
  id: string,
  canCreate: boolean,
  canRead: boolean,
  canUpdate: boolean,
  canDelete: boolean,
  permission: Permission,
  parentUserPermission?: UserPermission,
  childUserPermissions?: UserPermission[]
}
