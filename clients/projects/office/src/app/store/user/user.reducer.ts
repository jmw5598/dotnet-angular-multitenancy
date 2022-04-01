import { createReducer, on } from '@ngrx/store';

import { UserPermissions, UserSettings } from '@xyz/office/modules/core/models';
import * as fromUser from './user.actions';

export const userFeatureKey = 'user';

export interface UserState {
  userSettings: UserSettings | null,
  userPermissionsMap: UserPermissions | null
}

export const initialUserState: UserState = {
  userSettings: null,
  userPermissionsMap: null
}


export const reducer = createReducer(
  initialUserState
);
