import { Role, UserModulePermission, Profile } from "../entities";

export interface UserAccountDto {
  id: string,
  userName: string,
  email: string,
  profile: Profile,
  roles?: Role[]
  userModulePermissions?: UserModulePermission[]
}
