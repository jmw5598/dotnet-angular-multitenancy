import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromTenant from './tenant.reducer';

export const selectTenantState = createFeatureSelector<fromTenant.TenantState>(
  fromTenant.tenantFeatureKey
);

export const selectTenant = createSelector(
  selectTenantState,
  (state: fromTenant.TenantState) => state.tenant
);

export const selectSearchCompaniesPage = createSelector(
  selectTenantState,
  (state: fromTenant.TenantState) => state.searchCompaniesPage
);

export const selectRegistartionResponseMessage = createSelector(
  selectTenantState,
  (state: fromTenant.TenantState) => state.registrationRequestResponseMessage
);
