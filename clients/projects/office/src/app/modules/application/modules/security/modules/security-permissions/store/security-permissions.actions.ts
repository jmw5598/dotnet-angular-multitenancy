import { createAction } from "@ngrx/store";

export const getTemplateModulePermissionsRequest = createAction(
  '[Security Permissions] Get Template Module Permissions Request'
);

export const getTemplateModulePermissionsRequestSuccess = createAction(
  '[Security Permissions] Get Template Module Permissions Request Success'
);

export const getTemplateModulePermissionsRequestFailure = createAction(
  '[Security Permissions] Get Template Module Permissions Request Failure'
);
