import { Action, combineReducers, createFeatureSelector } from '@ngrx/store';

import * as fromUserAccounts from '../modules/user-accounts/store/user-accounts.reducer';
import { UserAccountsEffects } from '../modules/user-accounts/store/user-accounts.effects';

import * as fromAccountInformation from '../modules/account-details/store/account-information/account-information.reducer';
import { AccountInformationEffects } from '../modules/account-details/store/account-information/account-information.effects';

import * as fromBilling from '../modules/account-details/store/billing/billing.reducer';
import { BillingEffects } from '../modules/account-details/store/billing/billing.effects';

export const administrationFeatureKey = 'administration';

export interface AdministrationState {
  [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.UserAccountsState,
  [fromAccountInformation.accountInfomrationFeatureKey]: fromAccountInformation.AccountInformationState,
  [fromBilling.billingFeatureKey]: fromBilling.BillingState,
}

export function reducers(state: AdministrationState | undefined, action: Action) {
  return combineReducers({
    [fromUserAccounts.userAccountsFeatureKey]: fromUserAccounts.reducer,
    [fromAccountInformation.accountInfomrationFeatureKey]: fromAccountInformation.reducer,
    [fromBilling.billingFeatureKey]: fromBilling.reducer,
  })(state, action);
}

export const adminsitrationEffects = [
  UserAccountsEffects,
  AccountInformationEffects,
  BillingEffects,
];

export const selectAdministrationState = createFeatureSelector<AdministrationState>(
  administrationFeatureKey
);
