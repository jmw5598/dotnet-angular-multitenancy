import { createReducer, on } from '@ngrx/store';
import { defaultBasicQuerySearchFilter } from '@xyz/office/modules/core/constants';

import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { ModulePermission, TemplateModulePermissionName, UserPermission } from '@xyz/office/modules/core/entities';
import { Page, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {
  userAccountsPage: Page<UserAccountDto> | null,
  userAccountsSearchFilter: BasicQuerySearchFilter | null,
  createUserAccountResponseMessage: ResponseMessage | null,
  updateUserAccountResponseMessage: ResponseMessage | null,
  selectedUserAccount: UserAccountDto | null,
  selectedUsersPermissions: UserPermission[] | null,
  templateModulePermissionNames: TemplateModulePermissionName[] | null,
  selectedTemplateModulePermissionName: TemplateModulePermissionName | null,
}

export const initialUserAccountsState: UserAccountsState = {
  userAccountsPage: null,
  userAccountsSearchFilter: defaultBasicQuerySearchFilter,
  createUserAccountResponseMessage: null,
  updateUserAccountResponseMessage: null,
  selectedUserAccount: null,
  selectedUsersPermissions: null,
  templateModulePermissionNames: null,
  selectedTemplateModulePermissionName: null,
}

const handleSearchUserAccountsRequestSuccess = (state: UserAccountsState, { page }: any) => ({
  ...state,
  userAccountsPage: page
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

const handleGetTemplateModulePermissionNamesRequestSuccess = (state: UserAccountsState, { templateModulePermissionNames }: any) => ({
  ...state,
  templateModulePermissionNames: templateModulePermissionNames
} as UserAccountsState);

const handleGetTemplateModulePermissionNameByIdRequestSuccess = (state: UserAccountsState, { templateModulePermissionName }: any) => ({
  ...state,
  selectedTemplateModulePermissionName: templateModulePermissionName
} as UserAccountsState);

export const reducer = createReducer(
  initialUserAccountsState,
  on(
    fromUserAccounts.searchUserAccountsRequestSuccess,
    handleSearchUserAccountsRequestSuccess
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
  ),
  on(
    fromUserAccounts.getAllTemplateModulePermissionNamesRequestSuccess,
    fromUserAccounts.setTemplateModulePermissionNames,
    handleGetTemplateModulePermissionNamesRequestSuccess
  ),
  on(
    fromUserAccounts.getTemplateModulerPermissionNameByIdRequestSuccess,
    fromUserAccounts.setSelectedTemplateModulePermissionName,
    handleGetTemplateModulePermissionNameByIdRequestSuccess
  )
);
