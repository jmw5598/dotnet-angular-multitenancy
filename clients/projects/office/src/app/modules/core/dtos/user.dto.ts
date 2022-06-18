import { Role, UserModulePermission, Profile } from "../entities/tenants";

export interface UserAccountDto {
  id: string,
  userName: string,
  email: string,
  profile: Profile,
  roles?: Role[]
  userModulePermissions?: UserModulePermission[]
}
