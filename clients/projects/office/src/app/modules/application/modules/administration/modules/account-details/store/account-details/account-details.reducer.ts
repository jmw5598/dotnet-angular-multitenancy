import { createReducer, on } from '@ngrx/store';
import { TenantStatistics } from '@xyz/office/modules/core/models';

import * as fromAccountDetails from './account-details.actions';

export const accountDetailsFeatureKey = 'accountDetails';

export interface AccountDetailsState {
  tenantStatistics: TenantStatistics | null
}

export const initialAccountDetailsState: AccountDetailsState = {
  tenantStatistics: null
}

const handleGetTenantStatisticsRequestSuccess = (state: AccountDetailsState, { tenantStatistics }: any) => ({
  ...state,
  tenantStatistics: tenantStatistics
} as AccountDetailsState);

export const reducer = createReducer(
  initialAccountDetailsState,
  on(
    fromAccountDetails.getTenantStatisticsRequestSuccess,
    handleGetTenantStatisticsRequestSuccess
  )
);
