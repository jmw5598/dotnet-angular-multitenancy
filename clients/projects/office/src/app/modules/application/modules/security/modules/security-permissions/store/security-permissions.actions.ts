import { createAction, props } from "@ngrx/store";
import { TemplateModulePermissionName } from "@xyz/office/modules/core/entities";
import { BasicQuerySearchFilter, Page, PageRequest, ResponseMessage } from "@xyz/office/modules/core/models";

export const searchTemplateModulePerrmissionNamesRequest = createAction(
  '[Security Permissions] Search Template Module Permissions Names Request',
  props<{ filter: BasicQuerySearchFilter, pageRequest: PageRequest }>()
);

export const searchTemplateModulePerrmissionNamesRequestSuccess = createAction(
  '[Security Permissions] Search Template Module Permissions Names Request Success',
  props<{ page: Page<TemplateModulePermissionName> }>()
);

export const searchTemplateModulePerrmissionNamesRequestFailure = createAction(
  '[Security Permissions] Search Template Module Permissions Names Request Failure',
  props<{ message: ResponseMessage }>()
);

export const getTemplateModulePermissionNamesByIdRequest = createAction(
  '[Security Permissions] Get Template Module Permission Names By Id Request'
);

export const getTemplateModulePermissionNamesByIdRequestSuccess = createAction(
  '[Security Permissions] Get Template Module Permission Names By Id Request Success'
);

export const getTemplateModulePermissionNamesByIdRequestFailure = createAction(
  '[Security Permissions] Get Template Module Permission Names By Id Request Failure'
);
