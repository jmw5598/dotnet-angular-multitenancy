import { createFeatureSelector, createSelector } from "@ngrx/store";

import * as fromPermissions from './permissions.reducer';

export const selectPermissionsState = createFeatureSelector<fromPermissions.PermissionsState>(
  fromPermissions.permissionsFeatureKey
);

export const selectAssignableModulePermissions = createSelector(
  selectPermissionsState,
  (state: fromPermissions.PermissionsState) => state.assignableModulePermissions
);
