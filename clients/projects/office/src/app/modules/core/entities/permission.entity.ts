import { PermissionType } from "../models";

export interface Permission {
  id: string,
  type: PermissionType,
  name: string
}