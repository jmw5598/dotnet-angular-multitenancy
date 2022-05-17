import { Role, UserModulePermission } from "../entities";

export interface UserAccountDto {
  id: string,
  userName: string,
  email: string,
  firstName: string,
  lastName: string,
  avatarSrc: string,
  roles?: Role[]
  userModulePermissions?: UserModulePermission[]
}
