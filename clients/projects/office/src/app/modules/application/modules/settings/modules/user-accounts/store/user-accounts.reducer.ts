import { createReducer, on } from '@ngrx/store';

import { UserDto } from '@xyz/office/modules/core/dtos';
import { Page } from '@xyz/office/modules/core/models';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {
  userAccountsPage: Page<UserDto> | null;
}

export const initialUserAccountsState: UserAccountsState = {
  userAccountsPage: null
}

const handleSearchUserAccountsRequestSuccess = (state: UserAccountsState, { page }: any) => ({
  ...state,
  userAccountsPage: page
} as UserAccountsState);

export const reducer = createReducer(
  initialUserAccountsState,
  on(fromUserAccounts.searchUserAccountsRequestSuccess, handleSearchUserAccountsRequestSuccess)
);
