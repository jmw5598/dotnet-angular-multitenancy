import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, mergeMap, of } from "rxjs";

import { Credentials, ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";
import { AuthenticationService } from "../services/authentication.service";

import * as fromAuthentication from './authentication.actions';

@Injectable()
export class AuthenticationEffects {
  constructor(
    private _actions: Actions,
    private _authenticationService: AuthenticationService
  ) { }

  public loginUserReqeust$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.loginUserRequest),
      exhaustMap(({ credentials }) => this._authenticationService.loginUser(credentials)
        .pipe(
          mergeMap(authenticatedUser => 
            of(fromAuthentication.loginUserSuccess({ authenticatedUser: authenticatedUser }))),
          catchError(error => 
            of(fromAuthentication.loginUserFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.message || 'Invalid username/password!'
            } as ResponseMessage })))
        )
      )
    )
  );

  public passwordResetReqeust$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.passwordResetRequest),
      exhaustMap(({ request }) => this._authenticationService.requestPasswordReset(request)
        .pipe(
          mergeMap(message => 
            of(fromAuthentication.passwordResetRequestSuccess({ message }))),
          catchError(error => 
            of(fromAuthentication.passwordResetRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.message || 'Error sending password reset request!'
            } as ResponseMessage })))
        )
      )
    )
  );
}
