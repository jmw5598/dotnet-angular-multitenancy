import { UserPermission } from "../../entities";
import { RegistrationProfile } from "../authentication/registration-profile.model";
import { RegistrationUser } from "../authentication/registration-user.model";

export interface UserAccount {
  user: RegistrationUser,
  profile: RegistrationProfile,
  userPermissions: UserPermission[]
}