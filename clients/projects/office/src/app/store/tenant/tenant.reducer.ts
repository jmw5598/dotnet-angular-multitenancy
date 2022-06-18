import { createReducer, on } from '@ngrx/store';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';

import * as fromTenant from './tenant.actions';

export const tenantFeatureKey = 'tenant';

export interface TenantState {
  tenant: Tenant | null,
}

export const initialTenantState: TenantState = {
  tenant: null,
}

const handleGetTenantFromSubdomainRequestSuccess = (state: TenantState, { tenant }: any) => ({
  ...state,
  tenant: tenant
} as TenantState);

export const reducer = createReducer(
  initialTenantState,
  on(
    fromTenant.getTenantFromSubdomainRequestSuccess, 
    handleGetTenantFromSubdomainRequestSuccess
  ),
);
