import { Permission } from './permission.entity';
import { UserModulePermission } from './user-module-permission.entity';

export interface UserPermission {
  id: string,
  canCreate: boolean,
  canRead: boolean,
  canUpdate: boolean,
  canDelete: boolean,
  permissionId: string,
  permission?: Permission,
  userModulePermissionId: string,
  userModulePermission?: UserModulePermission
}
