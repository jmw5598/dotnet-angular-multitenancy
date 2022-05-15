import { Action, combineReducers, createFeatureSelector } from '@ngrx/store';

import * as fromUserAccounts from '../modules/user-accounts/store/user-accounts.reducer';
import { UserAccountsEffects } from '../modules/user-accounts/store/user-accounts.effects';

export const administrationFeatureKey = 'administration';

export interface AdministrationState {
  [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.UserAccountsState;
}

export function reducers(state: AdministrationState | undefined, action: Action) {
  return combineReducers({
    [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.reducer
  })(state, action);
}

export const adminsitrationEffects = [
  UserAccountsEffects
];

export const selectAdministrationState = createFeatureSelector<AdministrationState>(
  administrationFeatureKey
);
