import { createAction, props } from "@ngrx/store";
import { Tenant } from "@xyz/office/modules/core/entities";
import { ResponseMessage } from "@xyz/office/modules/core/models";

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
