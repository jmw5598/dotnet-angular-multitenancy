import { Action, combineReducers, createFeatureSelector } from '@ngrx/store';

import * as fromUserAccounts from '../modules/user-accounts/store/user-accounts.reducer';
import { UserAccountsEffects } from '../modules/user-accounts/store/user-accounts.effects';

export const settingsFeatureKey = 'settings';

export interface SettingsState {
  [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.UserAccountsState;
}

export function reducers(state: SettingsState | undefined, action: Action) {
  return combineReducers({
    [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.reducer
  })(state, action);
}

export const settingsEffects = [
  UserAccountsEffects
];

export const selectSettingsState = createFeatureSelector<SettingsState>(
  settingsFeatureKey
);
