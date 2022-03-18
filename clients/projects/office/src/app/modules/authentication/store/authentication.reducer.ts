import { createReducer } from "@ngrx/store";

export const authenticationFeatureKey = 'authentication';

export interface AuthenticationState {

}

export const initialAuthenticationState: AuthenticationState = {

}

export const reducer = createReducer(
  initialAuthenticationState
);
