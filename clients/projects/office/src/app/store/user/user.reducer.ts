import { createReducer, on } from '@ngrx/store';
import { UserPermission } from '@xyz/office/modules/core/entities';

import { PermissionType, UserPermissions, UserSettings } from '@xyz/office/modules/core/models';
import * as fromUser from './user.actions';

export const userFeatureKey = 'user';

export interface UserState {
  userSettings: UserSettings | null,
  userPermissions: UserPermissions | null,
  userPermissionsMap: { [key: string]: UserPermission } | null
}

export const initialUserState: UserState = {
  userSettings: null,
  userPermissions: null,
  userPermissionsMap: null
}

const handleGetUserSettingsSuccess = (state: UserState, { settings }: any) => ({
  ...state,
  userSettings: settings
} as UserState);

const handleGetUserPermissionsSuccess = (state: UserState, { permissions }: any) => ({
  ...state,
  userPermissions: permissions,
  userPermissionsMap: permissions?.permissions?.reduce((obj: {[key: string]: UserPermission}, permission: UserPermission) => {
    obj[permission?.permission?.type] = permission
    return obj
  }, {} as { [key: string]: UserPermission })
} as UserState);

export const reducer = createReducer(
  initialUserState,
  on(fromUser.getUserSettingsRequestSuccess, handleGetUserSettingsSuccess),
  on(fromUser.getUserPermissionsRequestSuccess, handleGetUserPermissionsSuccess)
);
