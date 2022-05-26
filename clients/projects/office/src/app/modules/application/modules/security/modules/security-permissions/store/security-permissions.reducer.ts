import { createReducer, on } from '@ngrx/store';
import { defaultBasicQuerySearchFilter } from '@xyz/office/modules/core/constants';

import { Page, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromSecurityPermissions from './security-permissions.actions';

export const securityPermissionsFeatureKey = 'securityPermissions';

export interface SecurityPermissionsState {
  createTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  templateModulePermissionNamesPage: Page<any> | null,
  templateModulePermissionsSearchFilter: BasicQuerySearchFilter | null,
}

export const initialSecurityPermissionsState: SecurityPermissionsState = {
  createTemplateModulePermissionNameResponseMessage: null,
  templateModulePermissionNamesPage: null,
  templateModulePermissionsSearchFilter: defaultBasicQuerySearchFilter
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
  createTemplateModulePermissionNameResponseMessage: message
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
  )
);
