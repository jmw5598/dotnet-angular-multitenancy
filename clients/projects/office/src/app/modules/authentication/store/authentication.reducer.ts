import { Action, ActionType, createReducer, on } from "@ngrx/store";
import { OnReducer } from "@ngrx/store/src/reducer_creator";
import { AuthenticatedUser, ResponseMessage } from "../../core/models";

import * as fromAuthentication from './authentication.actions';

export const authenticationFeatureKey = 'authentication';

export interface AuthenticationState {
  loginResponseMessage: ResponseMessage | null,
  authenticatedUser: AuthenticatedUser | null
}

export const initialAuthenticationState: AuthenticationState = {
  loginResponseMessage: null,
  authenticatedUser: null
}

const handleLoginUserSuccess = (state: AuthenticationState, { authenticatedUser }: any) => ({
  ...state,
  authenticatedUser: authenticatedUser
} as AuthenticationState);

const handleLoginUserFailure = (state: AuthenticationState, { message }: any) => ({
  ...state,
  loginResponseMessage: message
} as AuthenticationState);

export const reducer = createReducer(
  initialAuthenticationState,
  on(fromAuthentication.authenticateUserSuccess, handleLoginUserSuccess),
  on(fromAuthentication.authenticateUserFailure, handleLoginUserFailure)
);
