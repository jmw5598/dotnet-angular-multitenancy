import { Action, combineReducers, createFeatureSelector } from '@ngrx/store';

import * as fromSecurityPermissions from '../modules/security-permissions/store/security-permissions.reducer';
import { SecurityPermissionsEffects } from '../modules/security-permissions/store/security-permissions.effects';

export const securityFeatureKey = 'security';

export interface SecurityState {
  [fromSecurityPermissions.securityPermissionsFeatureKey]: fromSecurityPermissions.SecurityPermissionsState;
}

export function reducers(state: SecurityState | undefined, action: Action) {
  return combineReducers({
    [fromSecurityPermissions.securityPermissionsFeatureKey]: fromSecurityPermissions.reducer
  })(state, action);
}

export const securityEffects = [
  SecurityPermissionsEffects
];

export const selectSecurityState = createFeatureSelector<SecurityState>(
  securityFeatureKey
);
