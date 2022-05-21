import { createReducer } from '@ngrx/store';

import * as fromSecurityPermissions from './security-permissions.actions';

export const securityPermissionsFeatureKey = 'securityPermissions';

export interface SecurityPermissionsState {
}

export const initialSecurityPermissionsState: SecurityPermissionsState = {
}

export const reducer = createReducer(
  initialSecurityPermissionsState
);
