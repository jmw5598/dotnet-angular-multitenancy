import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromUser from './user.reducer';

export const selectUserState = createFeatureSelector<fromUser.UserState>(
  fromUser.userFeatureKey
);

export const selectUserSettings = createSelector(
  selectUserState,
  (state: fromUser.UserState) => state.userSettings
);

export const selectUserModulePermissionsMap = createSelector(
  selectUserState,
  (state: fromUser.UserState) => state.userModulePermissionsMap
);
