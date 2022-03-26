import { InjectionToken } from "@angular/core";
import { Action, ActionReducer, ActionReducerMap } from "@ngrx/store";

import { environment } from '@xyz/office/env/environment';

import * as fromAuthentication from '@xyz/office/modules/authentication/store';
import * as fromPlans from './plans';

export interface RootState {
  [fromAuthentication.authenticationFeatureKey]: fromAuthentication.AuthenticationState,
  [fromPlans.plansFeatureKey]: fromPlans.PlansState,
  // router: fromRouter.RouterReducerState<any>;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<RootState, Action>>(
  'Root reducers token', {
  factory: () => ({
    [fromAuthentication.authenticationFeatureKey]: fromAuthentication.reducer,
    [fromPlans.plansFeatureKey]: fromPlans.reducer,
    // router: fromRouter.routerReducer,
  }),
});

import { MetaReducer } from "@ngrx/store";

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

export const metaReducers: MetaReducer<RootState>[] = !environment.production
  ? [logger]
  : [];

export const rootEffects: any[] = [
  fromAuthentication.AuthenticationEffects,
  fromPlans.PlansEffects
];
