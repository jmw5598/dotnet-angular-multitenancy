import { createSelector } from "@ngrx/store";

import * as fromSecurity from '../../../store';
import * as fromSecurityPermissions from './security-permissions.reducer';

export const selectUserAccountsState = createSelector(
  fromSecurity.selectSecurityState,
  (state: fromSecurity.SecurityState) => state.securityPermissions 
);
