import { createAction, props } from '@ngrx/store';

import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { ModulePermission, UserPermission } from '@xyz/office/modules/core/entities';
import { Page, PageRequest, ResponseMessage, UserAccount } from '@xyz/office/modules/core/models';

export const searchUserAccountsRequest = createAction(
  '[User Accounts] Search User Accounts Request',
  props<{ pageRequest: PageRequest }>()
);

export const searchUserAccountsRequestSuccess = createAction(
  '[User Accounts] Search User Accounts Request Success',
  props<{ page: Page<UserAccountDto> }>()
);

export const searchUserAccountsRequestFailure = createAction(
  '[User Accounts] Search User Accounts Request Failure',
  props<{ message: ResponseMessage }>()
);

export const getAssignableModulePermissionsRequest = createAction(
  '[User Accounts] Get Assignable Module Permissions Request'
);

export const getAssignableModulePermissionsRequestSuccess = createAction(
  '[User Accounts] Get Assignable Module Permissions Request Success',
  props<{ permissions: ModulePermission[] }>()
);

export const getAssignableModulePermissionsRequestFailure = createAction(
  '[User Accounts] Get Assignable Module Permissions Request Failure',
  props<{ message: ResponseMessage }>()
);

export const createUserAccountRequest = createAction(
  '[User Accounts] Create User Account Request',
  props<{ userAccount: UserAccount }>()
);

export const createUserAccountRequestSuccess = createAction(
  '[User Accounts] Create User Account Request Success',
  props<{ message: ResponseMessage }>()
);

export const createUserAccountRequestFailure = createAction(
  '[User Accounts] Create User Account Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setCreateUserAccountRequestResponseMessage = createAction(
  '[User Accounts] Create User Account Request Response Message',
  props<{ message: ResponseMessage | null }>()
);

export const getUserAccountByUserIdRequest = createAction(
  '[User Accounts] Get User Account By User Id Request',
  props<{ userId: string }>()
);

export const getUserAccountByUserIdRequestSuccess = createAction(
  '[User Accounts] Get User Account By User Id Request Success',
  props<{ user: UserAccountDto | null }>()
);

export const getUserAccountByUserIdRequestFailure = createAction(
  '[User Accounts] Get User Account By User Id Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setSelectedUserAccount = createAction(
  '[User Accounts] Set Selected User Account',
  props<{ user: UserAccountDto | null }>()
);

export const getUserPermissionByUserIdRequest = createAction(
  '[User Accounts] Get User Permissions By User Id Request',
  props<{ userId: string }>()
);

export const getUserPermissionByUserIdRequestSuccess = createAction(
  '[User Accounts] Get User Permissions By User Id Request Success',
  props<{ userPermissions: UserPermission[] | null }>()
);

export const getUserPermissionByUserIdRequestFailure = createAction(
  '[User Accounts] Get User Permissions By User Id Request Failure',
  props<{ message: ResponseMessage }>()
);
