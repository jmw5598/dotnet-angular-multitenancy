import { BaseEntity } from "./base.entity";

export interface Plan extends BaseEntity {
  name: string;
  renewalRate: string,
  maxUserCount: number
}
