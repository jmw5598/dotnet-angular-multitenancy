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

export const selectTemplateModulePermissionSearchFilter = createSelector(
  selectSecurityPermissionsState,
  (state: fromSecurityPermissions.SecurityPermissionsState) => state.templateModulePermissionsSearchFilter
);

export const selectCreateTemplateModulePermissionNameResponseMessage = createSelector(
  selectSecurityPermissionsState,
  (state: fromSecurityPermissions.SecurityPermissionsState) => state.createTemplateModulePermissionNameResponseMessage
);

export const selectUpdateTemplateModulePermissionNameResponseMessage = createSelector(
  selectSecurityPermissionsState,
  (state: fromSecurityPermissions.SecurityPermissionsState) => state.updateTemplateModulePermissionNameResponseMessage
);

export const selectSelectedTemplateModulerPermissionName = createSelector(
  selectSecurityPermissionsState,
  (state: fromSecurityPermissions.SecurityPermissionsState) => state.selectedTemplateModulePermissionName
);
