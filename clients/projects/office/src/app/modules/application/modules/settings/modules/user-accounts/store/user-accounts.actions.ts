import { createAction, props } from '@ngrx/store';

import { UserDto } from '@xyz/office/modules/core/dtos';
import { Permission } from '@xyz/office/modules/core/entities';
import { Page, PageRequest, ResponseMessage } from '@xyz/office/modules/core/models';

export const searchUserAccountsRequest = createAction(
  '[User Accounts] Search User Accounts Request',
  props<{ pageRequest: PageRequest }>()
);

export const searchUserAccountsRequestSuccess = createAction(
  '[User Accounts] Search User Accounts Request Success',
  props<{ page: Page<UserDto> }>()
);

export const searchUserAccountsRequestFailure = createAction(
  '[User Accounts] Search User Accounts Request Failure',
  props<{ message: ResponseMessage }>()
);

export const getAssignablePermissionsRequest = createAction(
  '[User Accounts] Get Assignable Permissions Request'
);

export const getAssignablePermissionsRequestSuccess = createAction(
  '[User Accounts] Get Assignable Permissions Request Success',
  props<{ permissions: Permission[] }>()
);

export const getAssignablePermissionsRequestFailure = createAction(
  '[User Accounts] Get Assignable Permissions Request Failure',
  props<{ message: ResponseMessage }>()
);

export const createUserAccountRequest = createAction(
  '[User Accounts] Create User Account Request'
);

export const createUserAccountRequestSuccess = createAction(
  '[User Accounts] Create User Account Request Success',
  props<{ createUserAccountDto: any }>()
);

export const createUserAccountRequestFailure = createAction(
  '[User Accounts] Create User Account Request Failure',
  props<{ userAccount: any }>()
);
