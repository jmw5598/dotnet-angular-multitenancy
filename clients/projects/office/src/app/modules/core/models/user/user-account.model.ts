import { User, UserPermission } from "../../entities";

export interface UserAccount {
  user: User,
  userPermissions: UserPermission[]
}