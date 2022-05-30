import { User } from "./user.entity";

export interface BaseEntity {
  id: string,
  createdAt: Date,
  updatedAt: Date,
  deletedAt: Date,
  createdBy: User,
  updatedBy: User
}