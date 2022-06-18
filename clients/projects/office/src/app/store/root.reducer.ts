import { InjectionToken } from '@angular/core';
import { Action, ActionReducer, ActionReducerMap } from '@ngrx/store';

import { environment } from '@xyz/office/env/environment';

import * as fromAuthentication from '@xyz/office/modules/authentication/store';
import * as fromPlans from './plans';
import * as fromUser from './user';
import * as fromFiles from './files';
import * as fromPermissions from './permissions';
import * as fromTenant from './tenant';

export interface RootState {
  [fromAuthentication.authenticationFeatureKey]: fromAuthentication.AuthenticationState,
  [fromPlans.plansFeatureKey]: fromPlans.PlansState,
  [fromUser.userFeatureKey]: fromUser.UserState,
  [fromFiles.filesFeatureKey]: fromFiles.FilesState,
  [fromPermissions.permissionsFeatureKey]: fromPermissions.PermissionsState,
  [fromTenant.tenantFeatureKey]: fromTenant.TenantState,
  // router: fromRouter.RouterReducerState<any>;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<RootState, Action>>(
  'Root reducers token', {
  factory: () => ({
    [fromAuthentication.authenticationFeatureKey]: fromAuthentication.reducer,
    [fromPlans.plansFeatureKey]: fromPlans.reducer,
    [fromUser.userFeatureKey]: fromUser.reducer,
    [fromFiles.filesFeatureKey]: fromFiles.reducer,
    [fromPermissions.permissionsFeatureKey]: fromPermissions.reducer,
    [fromTenant.tenantFeatureKey]: fromTenant.reducer,
    // router: fromRouter.routerReducer,
  }),
});

import { MetaReducer } from '@ngrx/store';
import { TenantEffects } from './tenant';

export function logger(reducer: ActionReducer<RootState>): ActionReducer<RootState> {
  return (state, action) => {
    const result = reducer(state, action);
    console.groupCollapsed(action.type);
    console.log('prev state', state);
    console.log('action', action);
    console.log('next state', result);
    console.groupEnd();

    return result;
  };
}

// Meta reducer to reset state on logout
export function resetState(reducer: ActionReducer<RootState>): ActionReducer<RootState> {
  return (state, action) => {
    if (action.type === fromAuthentication.logoutUserSuccess.type) {
      state = undefined;
    }

    return reducer(state, action);
  };
}

export const metaReducers: MetaReducer<RootState>[] = !environment.production
  ? [logger, resetState]
  : [resetState];

export const rootEffects: any[] = [
  fromAuthentication.AuthenticationEffects,
  fromPlans.PlansEffects,
  fromUser.UserEffects,
  fromFiles.FilesEffects,
  fromPermissions.PermissionsEffects,
  fromTenant.TenantEffects
];
