import { BaseEntity } from "./base.entity";

export interface Profile extends BaseEntity {
  firstName: string,
  lastname: string
}
