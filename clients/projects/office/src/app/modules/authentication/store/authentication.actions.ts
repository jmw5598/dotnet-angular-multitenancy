import { createAction, props } from "@ngrx/store";
import { Credentials, AuthenticatedUser, ResponseMessage, PasswordReset } from "@xyz/office/modules/core/models";

export const loginUserRequest = createAction(
  '[Authentication] Login User Request',
  props<{ credentials: Credentials }>()
);

export const loginUserSuccess = createAction(
  '[Authentication] Login User Success',
  props<{ authenticatedUser: AuthenticatedUser }>()
);

export const loginUserFailure = createAction(
  '[Authentication] Login User Failure',
  props<{ message: ResponseMessage }>()
);

export const passwordResetRequest = createAction(
  '[Authentication] Password Reset Reqeust',
  props<{ request: PasswordReset }>()
);

export const passwordResetRequestSuccess = createAction(
  '[Authentication] Password Reset Reqeust Success',
  props<{ message: ResponseMessage }>()
);

export const passwordResetRequestFailure = createAction(
  '[Authentication] Password Reset Reqeust Failure',
  props<{ message: ResponseMessage }>()
);

export const logoutUserRequest = createAction(
  '[Authentication] Logout User Request'
);

export const logoutUserSuccess = createAction(
  '[Authentication] Logout User Success'
);

export const refreshAccessToken = createAction(
  '[Authentication] Refresh Access Token'
  // @TODO accept props??
);

// @TODO actions to actually do the reset and success/failure for that action
