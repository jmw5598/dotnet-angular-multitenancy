import { createAction, props } from "@ngrx/store";
import { Credentials, AuthenticatedUser, ResponseMessage } from "@xyz/office/modules/core/models";

export const authenticateUserRequest = createAction(
  '[Authentication] Authenticate User Request',
  props<{ credentials: Credentials }>()
);

export const authenticateUserSuccess = createAction(
  '[Authentication] Authenticate User Success',
  props<{ authenticatedUser: AuthenticatedUser }>()
);

export const authenticateUserFailure = createAction(
  '[Authentication] Authenticate User Failure',
  props<{ message: ResponseMessage }>()
);
