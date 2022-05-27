import { createReducer, on } from '@ngrx/store';
import { defaultBasicQuerySearchFilter } from '@xyz/office/modules/core/constants';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

import { Page, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { elementAt } from 'rxjs';

import * as fromSecurityPermissions from './security-permissions.actions';

export const securityPermissionsFeatureKey = 'securityPermissions';

export interface SecurityPermissionsState {
  createTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  updateTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  deleteTemplateModulePermissionNameResponseMessage: ResponseMessage | null,
  templateModulePermissionNamesPage: Page<any> | null,
  templateModulePermissionsSearchFilter: BasicQuerySearchFilter | null,
  selectedTemplateModulePermissionName: TemplateModulePermissionName | null,
}

export const initialSecurityPermissionsState: SecurityPermissionsState = {
  createTemplateModulePermissionNameResponseMessage: null,
  updateTemplateModulePermissionNameResponseMessage: null,
  deleteTemplateModulePermissionNameResponseMessage: null,
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

const handleDeleteTemplatePermissionModuleNameRequestSuccess = (state: SecurityPermissionsState, { templateModulePermissionName }: any) => {
  const templateModulePermissionNamesPage: Page<TemplateModulePermissionName> | null = !state?.templateModulePermissionNamesPage ? null : {
    ...state.templateModulePermissionNamesPage,
    
    // Removes the elment from the page
    elements: state.templateModulePermissionNamesPage
      ?.elements?.filter((template: TemplateModulePermissionName) => {
        return template.id !== templateModulePermissionName.id 
      }) 
      || [],
    
    // Update total elements
    totalElements: state.templateModulePermissionNamesPage.totalElements > 0 
      ? state.templateModulePermissionNamesPage.totalElements - 1 
      : 0
  } as Page<TemplateModulePermissionName>;

  console.log(templateModulePermissionNamesPage);
  
  return {
    ...state,
    templateModulePermissionNamesPage: templateModulePermissionNamesPage
  } as SecurityPermissionsState
};

const handleSetDeleteTemplatePermissionModuleNameResponseMessage = (state: SecurityPermissionsState, { message }: any) => ({
  ...state,
  deleteTemplateModulePermissionNameResponseMessage: message
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
  ),
  on(
    fromSecurityPermissions.deleteTemplateModulePermissionNameRequestSuccess,
    handleDeleteTemplatePermissionModuleNameRequestSuccess
  ),
  on(
    fromSecurityPermissions.setDeleteTemplateModulePermissionNameResponseMessage,
    handleSetDeleteTemplatePermissionModuleNameResponseMessage
  )
);
