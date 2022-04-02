import { ModulePermissionType } from "../models";

export interface Permission {
  id: string,
  type: ModulePermissionType,
  name: string
}