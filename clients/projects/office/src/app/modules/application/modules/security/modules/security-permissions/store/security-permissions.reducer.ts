import { createReducer, on } from '@ngrx/store';
import { defaultBasicQuerySearchFilter } from '@xyz/office/modules/core/constants';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

import { Page, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromSecurityPermissions from './security-permissions.actions';

export const securityPermissionsFeatureKey = 'securityPermissions';

export interface SecurityPermissionsState {
  createTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  updateTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  templateModulePermissionNamesPage: Page<any> | null,
  templateModulePermissionsSearchFilter: BasicQuerySearchFilter | null,
  selectedTemplateModulePermissionName: TemplateModulePermissionName | null,
}

export const initialSecurityPermissionsState: SecurityPermissionsState = {
  createTemplateModulePermissionNameResponseMessage: null,
  updateTemplateModulePermissionNameResponseMessage: null,
  templateModulePermissionNamesPage: null,
  templateModulePermissionsSearchFilter: defaultBasicQuerySearchFilter,
  selectedTemplateModulePermissionName: null,
}

const handleSeachTemplateModulePermissionNamesRequestSuccess = (state: SecurityPermissionsState, { page }: any) => ({
  ...state,
  templateModulePermissionNamesPage: page
} as SecurityPermissionsState);

const handleSetTemplateModulePermissionsSearchFilter = (state: SecurityPermissionsState, { filter }: any) => ({
  ...state,
  templateModulePermissionsSearchFilter: filter
} as SecurityPermissionsState);

const handleCreateTemplateModulePermissionNameResponseMessage = (state: SecurityPermissionsState, { message }: any) => ({
  ...state,
  templateModulePermissionNamesPage: null,
  createTemplateModulePermissionNameResponseMessage: message
} as SecurityPermissionsState);

const handleUpdateTemplateModulePermissionNameResponseMessage = (state: SecurityPermissionsState, { message }: any) => ({
  ...state,
  templateModulePermissionNamesPage: null,
  updateTemplateModulePermissionNameResponseMessage: message
} as SecurityPermissionsState);

const handleGetTemplateModulePermissionNameByIdRequestSuccess = (state: SecurityPermissionsState, { templateModulePermissionName }: any) => ({
  ...state,
  selectedTemplateModulePermissionName: templateModulePermissionName
} as SecurityPermissionsState);

export const reducer = createReducer(
  initialSecurityPermissionsState,
  on(
    fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequestSuccess,
    handleSeachTemplateModulePermissionNamesRequestSuccess
  ),
  on(
    fromSecurityPermissions.setTemplateModulePermissionsSearchFilter,
    handleSetTemplateModulePermissionsSearchFilter
  ),
  on(
    fromSecurityPermissions.createTemplateModulePermissionNameRequestSuccess,
    fromSecurityPermissions.setCreateTemplateModulePermissionNameResponseMessage,
    handleCreateTemplateModulePermissionNameResponseMessage
  ),
  on(
    fromSecurityPermissions.updateTemplateModulePermissionNameRequestSuccess,
    fromSecurityPermissions.setUpdateTemplateModulePermissionNameResponseMessage,
    handleUpdateTemplateModulePermissionNameResponseMessage
  ),
  on(
    fromSecurityPermissions.getTemplateModulerPermissionNameByIdRequestSuccess,
    fromSecurityPermissions.setSelectedTemplateModulePermissionName,
    handleGetTemplateModulePermissionNameByIdRequestSuccess
  )
);
