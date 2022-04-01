import { UserPermission } from "../../entities/user-permission.entity";

export enum UserPermissionType {
  ACCOUNTS
}

export interface UserPermissions {
  permission: UserPermission
}

export class UserPermissionsMap {
  private _permissionsMap: Map<UserPermissionType, UserPermission>;

  constructor(permissions: UserPermission[]) {
    this._permissionsMap = new Map<UserPermissionType, UserPermission>();
    this._processInitialUserPermissions(permissions);
  }

  public getUserPermissionFromType(userPermissionType: UserPermissionType): UserPermission | null | undefined {
    return this._permissionsMap.get(userPermissionType);
  }

  private _processInitialUserPermissions(permissions: UserPermission[]): void {
    // @TODO
  }
}
