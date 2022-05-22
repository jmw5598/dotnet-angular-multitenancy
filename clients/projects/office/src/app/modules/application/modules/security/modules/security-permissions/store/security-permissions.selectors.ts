import { createSelector } from "@ngrx/store";

import * as fromSecurity from '../../../store';
import * as fromSecurityPermissions from './security-permissions.reducer';

export const selectSecurityPermissionsState = createSelector(
  fromSecurity.selectSecurityState,
  (state: fromSecurity.SecurityState) => state.securityPermissions 
);

export const selectTemplateModulePermissionNamesPage = createSelector(
  selectSecurityPermissionsState,
  (state: fromSecurityPermissions.SecurityPermissionsState) => state.templateModulePermissionNamesPage
);
