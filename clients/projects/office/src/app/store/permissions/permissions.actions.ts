import { createAction, props } from "@ngrx/store";

import { ModulePermission } from "@xyz/office/modules/core/entities";
import { ResponseMessage } from "@xyz/office/modules/core/models";

export const getAssignableModulePermissionsRequest = createAction(
  '[Security Permissions] Get Assignable Module Permissions Request'
);

export const getAssignableModulePermissionsRequestSuccess = createAction(
  '[Security Permissions] Get Assignable Module Permissions Request Success',
  props<{ permissions: ModulePermission[] }>()
);

export const getAssignableModulePermissionsRequestFailure = createAction(
  '[Security Permissions] Get Assignable Module Permissions Request Failure',
  props<{ message: ResponseMessage }>()
);
