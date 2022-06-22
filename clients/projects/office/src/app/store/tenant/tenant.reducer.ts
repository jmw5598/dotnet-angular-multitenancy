import { createReducer, on } from '@ngrx/store';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, ResponseMessage } from '@xyz/office/modules/core/models';

import * as fromTenant from './tenant.actions';

export const tenantFeatureKey = 'tenant';

export interface TenantState {
  tenant: Tenant | null,
  searchCompaniesPage: Page<Tenant> | null,
  registrationRequestResponseMessage: ResponseMessage | null,
}

export const initialTenantState: TenantState = {
  tenant: null,
  searchCompaniesPage: null,
  registrationRequestResponseMessage: null,
}

const handleGetTenantFromSubdomainRequestSuccess = (state: TenantState, { tenant }: any) => ({
  ...state,
  tenant: tenant
} as TenantState);

const handleSearchCompaniesRequestSuccess = (state: TenantState, { page }: any) => ({
  ...state,
  searchCompaniesPage: page
} as TenantState);


const handleRegistrationRequestResponse = (state: TenantState, { message }: any) => ({
  ...state,
  registrationRequestResponseMessage: message
} as TenantState);

export const reducer = createReducer(
  initialTenantState,
  on(
    fromTenant.getTenantFromSubdomainRequestSuccess, 
    handleGetTenantFromSubdomainRequestSuccess
  ),
  on(
    fromTenant.searchCompaniesRequestSuccess,
    fromTenant.setSearchCompaniesPage,
    handleSearchCompaniesRequestSuccess
  ),
  on(
    fromTenant.registrationRequestSuccess,
    fromTenant.registrationRequestFailure,
    fromTenant.setRegistrationResponseMessage,
    handleRegistrationRequestResponse
  ),
);
