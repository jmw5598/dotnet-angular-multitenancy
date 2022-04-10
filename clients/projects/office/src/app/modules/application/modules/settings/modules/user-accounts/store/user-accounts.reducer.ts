import { createReducer, on } from '@ngrx/store';

import { UserDto } from '@xyz/office/modules/core/dtos';
import { Permission } from '@xyz/office/modules/core/entities';
import { Page } from '@xyz/office/modules/core/models';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {
  userAccountsPage: Page<UserDto> | null;
  assignablePermissions: Permission[] | null;
}

export const initialUserAccountsState: UserAccountsState = {
  userAccountsPage: null,
  assignablePermissions: null
}

const handleSearchUserAccountsRequestSuccess = (state: UserAccountsState, { page }: any) => ({
  ...state,
  userAccountsPage: page
} as UserAccountsState);

const handleGetAssignablePermissionsRequestSuccess = (state: UserAccountsState, { permissions }: any) => ({
  ...state,
  assignablePermissions: permissions
} as UserAccountsState);

export const reducer = createReducer(
  initialUserAccountsState,
  on(
    fromUserAccounts.searchUserAccountsRequestSuccess,
    handleSearchUserAccountsRequestSuccess
  ),
  on(
    fromUserAccounts.getAssignablePermissionsRequestSuccess, 
    handleGetAssignablePermissionsRequestSuccess
  )
);
