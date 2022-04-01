import { createReducer, on } from '@ngrx/store';

import { UserPermissions, UserPermissionsMap, UserSettings } from '@xyz/office/modules/core/models';
import * as fromUser from './user.actions';

export const userFeatureKey = 'user';

export interface UserState {
  userSettings: UserSettings | null,
  userPermissionsMap: UserPermissionsMap | null
}

export const initialUserState: UserState = {
  userSettings: null,
  userPermissionsMap: null
}

const handleGetUserSettingsSuccess = (state: UserState, { settings }: any) => ({
  ...state,
  userSettings: settings
} as UserState);

const handleGetUserPermissionsSuccess = (state: UserState, { permissions }: any) => ({
  ...state,
  userPermissionsMap: new UserPermissionsMap(permissions?.permissions || [])
} as UserState);

export const reducer = createReducer(
  initialUserState,
  on(fromUser.getUserSettingsRequestSuccess, handleGetUserSettingsSuccess),
  on(fromUser.getUserPermissionsRequestSuccess, handleGetUserPermissionsSuccess)
);
