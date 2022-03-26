import { BaseEntity } from "./base.entity";

export interface User extends BaseEntity{
  userName: string,
  email: string,
}
