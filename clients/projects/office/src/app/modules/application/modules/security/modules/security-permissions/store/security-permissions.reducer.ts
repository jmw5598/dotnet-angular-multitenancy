import { createReducer, on } from '@ngrx/store';

import { Page } from '@xyz/office/modules/core/models';

import * as fromSecurityPermissions from './security-permissions.actions';

export const securityPermissionsFeatureKey = 'securityPermissions';

export interface SecurityPermissionsState {
  templateModulePermissionNamesPage: Page<any> | null
}

export const initialSecurityPermissionsState: SecurityPermissionsState = {
  templateModulePermissionNamesPage: null
}

const handleSeachTemplateModulePermissionNamesRequestSuccess = (state: SecurityPermissionsState, { page }: any) => ({
  ...state,
  templateModulePermissionNamesPage: page
} as SecurityPermissionsState);

export const reducer = createReducer(
  initialSecurityPermissionsState,
  on(
    fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequestSuccess,
    handleSeachTemplateModulePermissionNamesRequestSuccess
  )
);
