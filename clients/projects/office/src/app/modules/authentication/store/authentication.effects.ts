import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, mergeMap, of, switchMap, tap } from "rxjs";

import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";
import { AuthenticationService } from "../services/authentication.service";

import * as fromAuthentication from './authentication.actions';
import { Router } from "@angular/router";

@Injectable()
export class AuthenticationEffects {
  constructor(
    private _actions: Actions,
    private _authenticationService: AuthenticationService,
    private _router: Router
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

  public loginUserSuccess$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.loginUserSuccess),
      tap(message => this._router.navigateByUrl('/auth/logging-in'))
    ), { dispatch: false });

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

  public logoutUserRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.logoutUserRequest),
      switchMap(() => {
        // @Note - do any side effects before logginout...
        return of(fromAuthentication.logoutUserSuccess());
      })
    ));
}
