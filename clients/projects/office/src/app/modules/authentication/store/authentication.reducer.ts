import { createReducer, on } from "@ngrx/store";
import { AuthenticatedUser, ResponseMessage } from "../../core/models";

import * as fromAuthentication from './authentication.actions';

export const authenticationFeatureKey = 'authentication';

export interface AuthenticationState {
  loginResponseMessage: ResponseMessage | null,
  refreshAccessTokenResponseMessage: ResponseMessage | null,
  authenticatedUser: AuthenticatedUser | null,
  passwordResetRequestResponseMessage: ResponseMessage | null,
  registrationRequestResponseMessage: ResponseMessage | null
}

export const initialAuthenticationState: AuthenticationState = {
  loginResponseMessage: null,
  refreshAccessTokenResponseMessage: null,
  authenticatedUser: null,
  passwordResetRequestResponseMessage: null,
  registrationRequestResponseMessage: null
}

const handleLoginUserSuccess = (state: AuthenticationState, { authenticatedUser }: any) => ({
  ...state,
  authenticatedUser: authenticatedUser,
  loginResponseMessage: null
} as AuthenticationState);

const handleLoginUserFailure = (state: AuthenticationState, { message }: any) => ({
  ...state,
  loginResponseMessage: message
} as AuthenticationState);

const handlePasswordResetRequestResponse = (state: AuthenticationState, { message }: any) => ({
  ...state,
  passwordResetRequestResponseMessage: message
} as AuthenticationState);

const handleLogoutUserSuccess = (state: AuthenticationState) => ({
  ...state,
  authenticatedUser: null,
  loginResponseMessage: null,
  passwordResetRequestResponseMessage: null
} as AuthenticationState);

const handleSetAuthenticatedUser = (state: AuthenticationState, { authenticatedUser }: any) => ({
  ...state,
  authenticatedUser: authenticatedUser
} as AuthenticationState);

const handleRegistrationRequestResponse = (state: AuthenticationState, { message }: any) => ({
  ...state,
  registrationRequestResponseMessage: message
} as AuthenticationState);

const handleRefreshTokenRequestSuccess = (state: AuthenticationState, { authenticatedUser }: any) => ({
  ...state,
  authenticatedUser: authenticatedUser
} as AuthenticationState);

const handleSetRefreshTokenResponseMessage = (state: AuthenticationState, { message }: any) => ({
  ...state,
  refreshAccessTokenResponseMessage: message
} as AuthenticationState);

export const reducer = createReducer(
  initialAuthenticationState,
  on(
    fromAuthentication.loginUserSuccess, 
    handleLoginUserSuccess
  ),
  on(
    fromAuthentication.loginUserFailure, 
    handleLoginUserFailure
  ),
  on(
    fromAuthentication.passwordResetRequestSuccess, 
    fromAuthentication.passwordResetRequestFailure, 
    handlePasswordResetRequestResponse),
  on(
    fromAuthentication.logoutUserSuccess, 
    handleLogoutUserSuccess
  ),
  on(
    fromAuthentication.setAuthenticatedUser, 
    handleSetAuthenticatedUser
  ),
  on(
    fromAuthentication.registrationRequestSuccess,
    fromAuthentication.registrationRequestFailure,
    fromAuthentication.setRegistrationResponseMessage,
    handleRegistrationRequestResponse
  ),
  on(
    fromAuthentication.refreshAccessTokenRequestSuccess,
    handleRefreshTokenRequestSuccess
  ),
  on(
    fromAuthentication.refreshAccessTokenRequestFailure,
    fromAuthentication.setRefreshAccessTokenResponseMessage,
    handleSetRefreshTokenResponseMessage
  )
);
