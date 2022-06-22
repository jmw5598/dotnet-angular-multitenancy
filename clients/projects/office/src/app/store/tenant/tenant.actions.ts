import { createAction, props } from '@ngrx/store';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, PageRequest, Registration, ResponseMessage } from '@xyz/office/modules/core/models';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

export const getTenantFromSubdomainRequest = createAction(
  '[Tenant] Get Tenant From Subdomain Request',
  props<{ subdomain: string }>()
);

export const getTenantFromSubdomainRequestSuccess = createAction(
  '[Tenant] Get Tenant From Subdomain Request Success',
  props<{ tenant: Tenant }>()
);

export const getTenantFromSubdomainRequestFailure = createAction(
  '[Tenant] Get Tenant From Subdomain Request Failure',
  props<{ message: ResponseMessage }>()
);

export const searchCompaniesRequest = createAction(
  '[Tenant] Search Companies Request',
  props<{ filter: BasicQuerySearchFilter, pageRequest: PageRequest }>()
);

export const searchCompaniesRequestSuccess = createAction(
  '[Tenant] Search Companies Request Success',
  props<{ page: Page<Tenant> }>()
);

export const searchCompaniesRequestFailure = createAction(
  '[Tenant] Search Companies Request Failure',
  props<{ message: ResponseMessage  }>()
);

export const setSearchCompaniesPage = createAction(
  '[Tenant] Set Search Companies Page',
  props<{ page: Page<Tenant> | null  }>()
);

export const registrationRequest = createAction(
  '[Tenant] Registration Request',
  props<{ registration: Registration }>()
);

export const registrationRequestSuccess = createAction(
  '[Tenant] Registration Request Success',
  props<{ message: ResponseMessage | null }>()
);

export const registrationRequestFailure = createAction(
  '[Tenant] Registration Request Failure',
  props<{ message: ResponseMessage | null }>()
);

export const setRegistrationResponseMessage = createAction(
  '[Tenant] Set Registration Response Message',
  props<{ message: ResponseMessage | null }>()
);
