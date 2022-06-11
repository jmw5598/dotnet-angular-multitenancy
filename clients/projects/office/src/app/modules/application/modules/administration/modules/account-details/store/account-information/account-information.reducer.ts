import { createReducer, on } from '@ngrx/store';

import * as fromAccountInformation from './account-information.actions';

export const accountInfomrationFeatureKey = 'accountInfomration';

export interface AccountInformationState {
}

export const initialAccountInformationState: AccountInformationState = {
}

export const reducer = createReducer(
  initialAccountInformationState
);
