import { createReducer, on } from '@ngrx/store';

import * as fromUserAccounts from './user-accounts.actions';

export const userAccountsFeatureKey = 'userAccounts';

export interface UserAccountsState {

}

export const initialUserAccountsState: UserAccountsState = {

}

export const reducer = createReducer(
  initialUserAccountsState,
);
