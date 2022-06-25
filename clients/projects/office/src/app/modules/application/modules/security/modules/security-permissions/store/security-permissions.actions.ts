import { createAction, props } from '@ngrx/store';

import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities/tenants';
import { Page, PageRequest, ResponseMessage } from '@xyz/office/modules/core/models';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

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

export const updateTemplateModulePermissionNameRequest = createAction(
  '[Security Permissions] Update Template Module Permission Name Request',
  props<{ templateModulePermissionNameId: string, templateModulePermissionName: TemplateModulePermissionName }>()
);

export const updateTemplateModulePermissionNameRequestSuccess = createAction(
  '[Security Permissions] Update Template Module Permission Name Request Success',
  props<{ message: ResponseMessage }>()
);

export const updateTemplateModulePermissionNameRequestFailure = createAction(
  '[Security Permissions] Update Template Module Permission Name Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setUpdateTemplateModulePermissionNameResponseMessage = createAction(
  '[Security Permissions] Set Update Template Module Permission Name Response Message',
  props<{ message: ResponseMessage | null }>()
);

export const getTemplateModulerPermissionNameByIdRequest = createAction(
  '[Security Permissions] Get Template Moduler Permission Name By Id Request',
  props<{ templateModulePermissionNameId: string }>()
);

export const getTemplateModulerPermissionNameByIdRequestSuccess = createAction(
  '[Security Permissions] Get Template Moduler Permission Name By Id Request Success',
  props<{ templateModulePermissionName: TemplateModulePermissionName }>()
);

export const getTemplateModulerPermissionNameByIdRequestFailure = createAction(
  '[Security Permissions] Get Template Moduler Permission Name By Id Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setSelectedTemplateModulePermissionName = createAction(
  '[Security Permissions] Set Selected Template Moduler Permission Name',
  props<{ templateModulePermissionName: TemplateModulePermissionName | null }>()
);

export const deleteTemplateModulePermissionNameRequest = createAction(
  '[Security Permissions] Delete Template Module Permission Name Request',
  props<{ templateModulePermissionNameId: string }>()
);

export const deleteTemplateModulePermissionNameRequestSuccess = createAction(
  '[Security Permissions] Delete Template Module Permission Name Request Success',
  props<{ templateModulePermissionName: TemplateModulePermissionName }>()
);

export const deleteTemplateModulePermissionNameRequestFailure = createAction(
  '[Security Permissions] Delete Template Module Permission Name Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setDeleteTemplateModulePermissionNameResponseMessage = createAction(
  '[Security Permissions] Set Delete Template Module Permission Name Response Message',
  props<{ message: ResponseMessage }>()
);

export const setSecurityPermissionsTableDefinition = createAction(
  '[Security Permissions] Set Security Permissions Table Definition',
  props<{ tableDefinition: TableDefinition | null }>()
);

export const resetSecurityPermissionsTableDefinition = createAction(
  '[SecurityPermissions] Reset Security Permissions Table Definition'
);
