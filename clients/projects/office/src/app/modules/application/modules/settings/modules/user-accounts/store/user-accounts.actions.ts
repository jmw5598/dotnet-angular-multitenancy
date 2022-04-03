import { createAction, props } from '@ngrx/store';
import { Page, ResponseMessage } from '@xyz/office/modules/core/models';

export const getUserAccountsRequest = createAction(
  '[User Accounts] Get User Accounts Request'
);

export const getUserAccountsRequestSuccess = createAction(
  '[User Accounts] Get User Accounts Request Success',
  props<{ page: Page<any> }>()
);

export const getUserAccountsRequestFailure = createAction(
  '[User Accounts] Get User Accounts Request Failure',
  props<{ message: ResponseMessage }>()
);
