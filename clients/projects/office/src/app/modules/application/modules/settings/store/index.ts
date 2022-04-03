import { Action, combineReducers } from '@ngrx/store';
import * as fromUserAccounts from '../modules/user-accounts/store';

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
  fromUserAccounts.UserAccountsEffects
];
