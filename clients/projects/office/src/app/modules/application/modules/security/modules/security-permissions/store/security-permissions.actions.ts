import { createAction, props } from "@ngrx/store";

import { ModulePermission, TemplateModulePermissionName } from "@xyz/office/modules/core/entities";
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

export const setTemplateModulePermissionsSearchFilter = createAction(
  '[Security Permissions] Set Template Module Permissions Search Filter',
  props<{ filter: BasicQuerySearchFilter }>()
);

export const createTemplateModulePermissionNameRequest = createAction(
  '[Security Permissions] Create Template Module Permission Name Request',
  props<{ templateModulePermissionName: TemplateModulePermissionName }>()
);

export const createTemplateModulePermissionNameRequestSuccess = createAction(
  '[Security Permissions] Create Template Module Permission Name Request Success',
  props<{ message: ResponseMessage }>()
);

export const createTemplateModulePermissionNameRequestFailure = createAction(
  '[Security Permissions] Create Template Module Permission Name Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setCreateTemplateModulePermissionNameResponseMessage = createAction(
  '[Security Permissions] Set Create Template Module Permission Name Response Message',
  props<{ message: ResponseMessage | null }>()
);
