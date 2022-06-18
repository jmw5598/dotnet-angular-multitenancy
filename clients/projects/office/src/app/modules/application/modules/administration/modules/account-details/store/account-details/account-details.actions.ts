import { createAction, props } from '@ngrx/store';
import { ResponseMessage, TenantStatistics } from '@xyz/office/modules/core/models';

export const getTenantStatisticsRequest = createAction(
  '[Account Details] Get Tenant Statistics Request',
);

export const getTenantStatisticsRequestSuccess = createAction(
  '[Account Details] Get Tenant Statistics Request Success',
  props<{ tenantStatistics: TenantStatistics }>()
);

export const getTenantStatisticsRequestFailure = createAction(
  '[Account Details] Get Tenant Statistics Request Failure',
  props<{ message: ResponseMessage }>()
);

export const setTenantStatistics = createAction(
  '[Account Details] Set Tenant Statistics',
  props<{ tenantStatistics: TenantStatistics | null }>()
);
