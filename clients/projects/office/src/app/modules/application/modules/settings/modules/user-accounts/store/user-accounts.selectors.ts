import { createFeatureSelector, createSelector } from "@ngrx/store";

import * as fromUserAccounts from './user-accounts.reducer';

export const selectUserAccountsState = createFeatureSelector<fromUserAccounts.UserAccountsState>(
  fromUserAccounts.userAccountsFeatureKey
);
