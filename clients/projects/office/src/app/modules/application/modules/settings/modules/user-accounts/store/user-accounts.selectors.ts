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

export const selectAssignablePermissions = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.assignablePermissions || null
);

export const selectCreateUserAccountResponseMessage = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.createUserAccountResponseMessage || null
);

export const selectSelectedUsersPermissions = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.selectedUsersPermissions || null
);

export const selectSelectedUserAccount = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state.selectedUserAccount
);
