import { createReducer, on } from '@ngrx/store';
import { defaultBasicQuerySearchFilter } from '@xyz/office/modules/core/constants';

import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { ModulePermission, UserPermission } from '@xyz/office/modules/core/entities';
import { Page, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {
  userAccountsPage: Page<UserAccountDto> | null,
  userAccountsSearchFilter: BasicQuerySearchFilter | null,
  assignableModulePermissions: ModulePermission[] | null,
  createUserAccountResponseMessage: ResponseMessage | null,
  updateUserAccountResponseMessage: ResponseMessage | null,
  selectedUserAccount: UserAccountDto | null,
  selectedUsersPermissions: UserPermission[] | null
}

export const initialUserAccountsState: UserAccountsState = {
  userAccountsPage: null,
  userAccountsSearchFilter: defaultBasicQuerySearchFilter,
  assignableModulePermissions: null,
  createUserAccountResponseMessage: null,
  updateUserAccountResponseMessage: null,
  selectedUserAccount: null,
  selectedUsersPermissions: null
}

const handleSearchUserAccountsRequestSuccess = (state: UserAccountsState, { page }: any) => ({
  ...state,
  userAccountsPage: page
} as UserAccountsState);

const handleGetAssignableModulePermissionsRequestSuccess = (state: UserAccountsState, { permissions }: any) => ({
  ...state,
  assignableModulePermissions: permissions
} as UserAccountsState);

const handleCreateUserAccountRequestSuccess = (state: UserAccountsState, { message }: any) => ({
  ...state,
  userAccountsPage: null,
  createUserAccountResponseMessage: message
} as UserAccountsState);

const handleUpdateUserAccountRequestSuccess = (state: UserAccountsState, { message }: any) => ({
  ...state,
  userAccountsPage: null,
  updateUserAccountResponseMessage: message
} as UserAccountsState);

const handleGetUserPermissionsByUserIdRequestSuccess = (state: UserAccountsState, { userPermissions }: any) => ({
  ...state,
  selectedUsersPermissions: userPermissions
} as UserAccountsState);

const handleGetUserAccountByUserIdRequestSuccess = (state: UserAccountsState, { user }: any) => ({
  ...state,
  selectedUserAccount: user
} as UserAccountsState);

const handleSetUserAccountsSearchFilter = (state: UserAccountsState, { filter }: any) => ({
  ...state,
  userAccountsSearchFilter: filter
} as UserAccountsState);

export const reducer = createReducer(
  initialUserAccountsState,
  on(
    fromUserAccounts.searchUserAccountsRequestSuccess,
    handleSearchUserAccountsRequestSuccess
  ),
  on(
    fromUserAccounts.getAssignableModulePermissionsRequestSuccess, 
    handleGetAssignableModulePermissionsRequestSuccess
  ),
  on(
    fromUserAccounts.createUserAccountRequestSuccess,
    fromUserAccounts.setCreateUserAccountRequestResponseMessage,
    handleCreateUserAccountRequestSuccess
  ),
  on(
    fromUserAccounts.updateUserAccountRequestSuccess,
    fromUserAccounts.setUpdateUserAccountRequestResponseMessage,
    handleUpdateUserAccountRequestSuccess
  ),
  on(
    fromUserAccounts.getUserPermissionByUserIdRequestSuccess,
    handleGetUserPermissionsByUserIdRequestSuccess
  ),
  on(
    fromUserAccounts.getUserAccountByUserIdRequestSuccess,
    fromUserAccounts.setSelectedUserAccount,
    handleGetUserAccountByUserIdRequestSuccess
  ),
  on(
    fromUserAccounts.setUserAccountsSearchFilter,
    handleSetUserAccountsSearchFilter
  )
);
