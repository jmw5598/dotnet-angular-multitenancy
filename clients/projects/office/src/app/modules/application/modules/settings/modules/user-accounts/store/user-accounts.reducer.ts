import { createReducer, on } from '@ngrx/store';

import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { Permission, UserPermission } from '@xyz/office/modules/core/entities';
import { Page, ResponseMessage } from '@xyz/office/modules/core/models';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {
  userAccountsPage: Page<UserAccountDto> | null,
  assignablePermissions: Permission[] | null,
  createUserAccountResponseMessage: ResponseMessage | null,
  selectedUserAccount: UserAccountDto | null,
  selectedUsersPermissions: UserPermission[] | null
}

export const initialUserAccountsState: UserAccountsState = {
  userAccountsPage: null,
  assignablePermissions: null,
  createUserAccountResponseMessage: null,
  selectedUserAccount: null,
  selectedUsersPermissions: null
}


const handleSearchUserAccountsRequestSuccess = (state: UserAccountsState, { page }: any) => ({
  ...state,
  userAccountsPage: page
} as UserAccountsState);

const handleGetAssignablePermissionsRequestSuccess = (state: UserAccountsState, { permissions }: any) => ({
  ...state,
  assignablePermissions: permissions
} as UserAccountsState);

const handleCreateUserAccountRequestSuccess = (state: UserAccountsState, { message }: any) => ({
  ...state,
  userAccountsPage: null,
  createUserAccountResponseMessage: message
} as UserAccountsState);

const handleGetUserPermissionsByUserIdRequestSuccess = (state: UserAccountsState, { userPermissions }: any) => ({
  ...state,
  selectedUsersPermissions: userPermissions
} as UserAccountsState);

const handleGetUserAccountByUserIdRequestSuccess = (state: UserAccountsState, { user }: any) => ({
  ...state,
  selectedUserAccount: user
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
  ),
  on(
    fromUserAccounts.createUserAccountRequestSuccess,
    handleCreateUserAccountRequestSuccess
  ),
  on(
    fromUserAccounts.getUserPermissionByUserIdRequestSuccess,
    handleGetUserPermissionsByUserIdRequestSuccess
  ),
  on(
    fromUserAccounts.getUserAccountByUserIdRequestSuccess,
    fromUserAccounts.setSelectedUserAccount,
    handleGetUserAccountByUserIdRequestSuccess
  )
);
