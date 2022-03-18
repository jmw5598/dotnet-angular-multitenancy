import { createFeatureSelector } from "@ngrx/store";
import * as fromAuthentication from './authentication.reducer';

export const selectBooksState = createFeatureSelector<fromAuthentication.AuthenticationState>(
  fromAuthentication.authenticationFeatureKey
);
