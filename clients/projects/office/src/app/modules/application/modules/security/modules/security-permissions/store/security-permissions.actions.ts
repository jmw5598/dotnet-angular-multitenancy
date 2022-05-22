import { createAction, props } from "@ngrx/store";

import { TemplateModulePermissionName } from "@xyz/office/modules/core/entities";
import { Page, PageRequest, ResponseMessage } from "@xyz/office/modules/core/models";

import { BasicQuerySearchFilter } from "@xyz/office/modules/shared/modules/query-search-filter";

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
