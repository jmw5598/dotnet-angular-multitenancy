import { User, UserModulePermission } from '@xyz/office/modules/core/entities/tenants';

export interface UserAccount {
  user: User,
  userModulePermissions: UserModulePermission[]
}
