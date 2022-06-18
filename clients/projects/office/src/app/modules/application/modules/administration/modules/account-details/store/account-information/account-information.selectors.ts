import { createSelector } from '@ngrx/store';

import * as fromAdministration from '../../../../store';
import * as fromAccountInformation from './account-information.actions';

export const selectAccountInformationState = createSelector(
  fromAdministration.selectAdministrationState,
  (state: fromAdministration.AdministrationState) => state.accountInfomration 
);
