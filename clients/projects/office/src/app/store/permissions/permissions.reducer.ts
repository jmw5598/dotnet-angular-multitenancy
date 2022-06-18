import { createReducer, on } from '@ngrx/store';

import { ModulePermission } from '@xyz/office/modules/core/entities/tenants';

import * as fromPermissions from './permissions.actions';

export const permissionsFeatureKey = 'permissions';

export interface PermissionsState {
  assignableModulePermissions: ModulePermission[] | null
}

export const initialPermissionsState: PermissionsState = {
  assignableModulePermissions: null
}

const handleGetAssignableModulePermissionsRequestSuccess = (state: PermissionsState, { permissions }: any) => ({
  ...state,
  assignableModulePermissions: permissions
} as PermissionsState);

export const reducer = createReducer(
  initialPermissionsState,
  on(
    fromPermissions.getAssignableModulePermissionsRequestSuccess,
    handleGetAssignableModulePermissionsRequestSuccess
  )
);
