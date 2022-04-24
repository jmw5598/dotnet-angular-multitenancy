import { UserPermission } from "../entities";

export interface UserDto {
  id: string,
  userName: string,
  email: string,
  firstName: string,
  lastName: string,
  avatarSrc: string,
  userPermissions?: UserPermission[]
}
