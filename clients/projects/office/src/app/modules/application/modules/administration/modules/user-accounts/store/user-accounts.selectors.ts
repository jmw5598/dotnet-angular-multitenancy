import { createSelector } from '@ngrx/store';

import * as fromAdministration from '../../../store';
import * as fromUserAccounts from './user-accounts.reducer';

export const selectUserAccountsState = createSelector(
  fromAdministration.selectAdministrationState,
  (state: fromAdministration.AdministrationState) => state.userAccounts 
);

export const selectUserAccountsPage = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.userAccountsPage || null
);

export const selectCreateUserAccountResponseMessage = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.createUserAccountResponseMessage || null
);

export const selectUpdateUserAccountResponseMessage = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.updateUserAccountResponseMessage || null
);

export const selectSelectedUsersPermissions = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state?.selectedUsersPermissions || null
);

export const selectSelectedUserAccount = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state.selectedUserAccount
);

export const selectUserAccountSearchFilter = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state.userAccountsSearchFilter
);

export const selectTemplateModulePermissionNames = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state.templateModulePermissionNames
);

export const selectSelectedTemplateModulePermissionName = createSelector(
  selectUserAccountsState,
  (state: fromUserAccounts.UserAccountsState) => state.selectedTemplateModulePermissionName
);
