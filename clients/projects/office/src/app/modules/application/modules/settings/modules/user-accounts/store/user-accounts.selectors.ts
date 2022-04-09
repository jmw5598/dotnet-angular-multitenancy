import { createSelector } from "@ngrx/store";

import * as fromSettings from '../../../store';
import * as fromUserAccounts from './user-accounts.reducer';

export const selectUserAccountsState = createSelector(
  fromSettings.selectSettingsState,
  (state: fromSettings.SettingsState) => state.userAccounts 
);

export const selectUserAccountsPage = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.userAccountsPage || null
);