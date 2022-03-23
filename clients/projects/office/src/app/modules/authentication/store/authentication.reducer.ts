import { createReducer, on } from "@ngrx/store";
import { AuthenticatedUser, ResponseMessage } from "../../core/models";

import * as fromAuthentication from './authentication.actions';

export const authenticationFeatureKey = 'authentication';

export interface AuthenticationState {
  loginResponseMessage: ResponseMessage | null,
  authenticatedUser: AuthenticatedUser | null,
  passwordResetRequestResponseMessage: ResponseMessage | null,
}

export const initialAuthenticationState: AuthenticationState = {
  loginResponseMessage: null,
  authenticatedUser: null,
  passwordResetRequestResponseMessage: null
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

export const reducer = createReducer(
  initialAuthenticationState,
  on(fromAuthentication.loginUserSuccess, handleLoginUserSuccess),
  on(fromAuthentication.loginUserFailure, handleLoginUserFailure),
  on(
    fromAuthentication.passwordResetRequestSuccess, 
    fromAuthentication.passwordResetRequestFailure, 
    handlePasswordResetRequestResponse),
  on(fromAuthentication.logoutUserSuccess, handleLogoutUserSuccess),
  on(fromAuthentication.setAuthenticatedUser, handleSetAuthenticatedUser)
);
