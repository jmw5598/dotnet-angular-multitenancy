import { createAction, props } from "@ngrx/store";

export const authenticateUserRequest = createAction(
  '[Authentication] Authenticate User Request',
  props<{ username: string, password: string }>()
);

export const authenticateUserSuccess = createAction(
  '[Authentication] Authenticate User Success'
);

export const authenticateUserFailure = createAction(
  '[Authentication] Authenticate User Failure'
);
