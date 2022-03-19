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
      ofType(fromAuthentication.authenticateUserRequest),
      exhaustMap(({ credentials: Credentials }) => this._authenticationService.loginUser(Credentials)
        .pipe(
          mergeMap(authenticatedUser => 
            of(fromAuthentication.authenticateUserSuccess({ authenticatedUser: authenticatedUser }))),
          catchError(error => 
            of(fromAuthentication.authenticateUserFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.message || 'Invalid username/password!'
            } as ResponseMessage })))
        )
      )
    )
  );
}
