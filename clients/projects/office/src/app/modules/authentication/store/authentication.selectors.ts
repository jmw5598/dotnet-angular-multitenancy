import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromAuthentication from './authentication.reducer';

export const selectAuthenticationState = createFeatureSelector<fromAuthentication.AuthenticationState>(
  fromAuthentication.authenticationFeatureKey
);

export const selectAuthenticatedUser = createSelector(
  selectAuthenticationState,
  (state: fromAuthentication.AuthenticationState) => state.authenticatedUser
);

export const selectedLoginResponseMessage = createSelector(
  selectAuthenticationState,
  (state: fromAuthentication.AuthenticationState) => state.loginResponseMessage
);

export const selectedPasswordResetRequestResponseMessage = createSelector(
  selectAuthenticationState,
  (state: fromAuthentication.AuthenticationState) => state.passwordResetRequestResponseMessage
);

export const selectRegistartionResponseMessage = createSelector(
  selectAuthenticationState,
  (state: fromAuthentication.AuthenticationState) => state.registrationRequestResponseMessage
);

export const selectRefreshAccessTokenResponseMessage = createSelector(
  selectAuthenticationState,
  (state: fromAuthentication.AuthenticationState) => state.refreshAccessTokenResponseMessage
);
