import { createAction, props } from '@ngrx/store';
import { ResponseMessage, UserModulePermissions, UserSettings } from '@xyz/office/modules/core/models';

export const getUserSettingsRequest = createAction(
  '[User] Get User Settings Request'
);

export const getUserSettingsRequestSuccess = createAction(
  '[User] Get User Settings Request Success',
  props<{ settings: UserSettings }>()
);

export const getUserSettingsRequestFailure = createAction(
  '[User] Get User Settings Request Failure',
  props<{ message: ResponseMessage }>()
);

export const getUserPermissionsRequest = createAction(
  '[User] Get User Permissions Request'
);

export const getUserPermissionsRequestSuccess = createAction(
  '[User] Get User Permissions Request Success',
  props<{ userModulePermissions: UserModulePermissions }>()
);

export const getUserPermissionsRequestFailure = createAction(
  '[User] Get User Permissions Request Failure',
  props<{ message: ResponseMessage }>()
);
