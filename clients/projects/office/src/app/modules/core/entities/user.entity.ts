import { BaseEntity } from "./base.entity";
import { Company } from "./company.entity";
import { Profile } from "./profile.entity";

export interface User extends BaseEntity{
  userName: string,
  email: string,
  profile: Profile,
  company: Company
}
