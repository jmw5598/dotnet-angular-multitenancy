import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, mergeMap, of, switchMap, tap } from "rxjs";

import { ResponseMessage, ResponseStatus, Page } from "@xyz/office/modules/core/models";
import { AuthenticationService } from "../services/authentication.service";

import * as fromAuthentication from './authentication.actions';
import { Tenant } from "../../core/entities";

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
          mergeMap(authenticatedUser => {
            this._authenticationService.cacheAuthenticatedUser(authenticatedUser);
            return of(fromAuthentication.loginUserSuccess({ authenticatedUser: authenticatedUser }))
          }),
          catchError(error => {
            return of(fromAuthentication.loginUserFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error?.message || 'Invalid username/password!'
            } as ResponseMessage }))
          })
        )
      )
    )
  );

  public loginUserSuccess$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.loginUserSuccess),
      tap(message => this._router.navigateByUrl('/auth/logging-in'))
    ),
    { dispatch: false }
  );

  public refrshRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.refreshAccessTokenRequest),
      exhaustMap(({ refreshTokenRequest }) => this._authenticationService.refreshToken(refreshTokenRequest)
        .pipe(
          mergeMap(authenticatedUser => {
            this._authenticationService.cacheAuthenticatedUser(authenticatedUser);
            return of(fromAuthentication.refreshAccessTokenRequestSuccess({ authenticatedUser: authenticatedUser }))
          }),
          catchError(error => {
            console.log("effect, error refreshign access token")
            return of(fromAuthentication.refreshAccessTokenRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error?.message || 'Invalid username/password!'
            } as ResponseMessage }))
          })
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
              message: error?.error?.message || 'Error sending password reset request!'
            } as ResponseMessage })))
        )
      )
    )
  );

  public logoutUserRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.logoutUserRequest),
      switchMap(() => {
        this._authenticationService.removeCachedAuthenticatedUser();
        return of(fromAuthentication.logoutUserSuccess());
      })
    )
  );

  public registrationRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.registrationRequest),
      exhaustMap(({ registration }) => this._authenticationService.register(registration)
        .pipe(
          mergeMap(responseMessage => {
            return of(fromAuthentication.registrationRequestSuccess({ 
              message: responseMessage 
            }));
          }),
          catchError(error => {
            return of(fromAuthentication.registrationRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error?.message || 'New registration failed. Please try again!'
            } as ResponseMessage }));
          })
        )
      )
    )
  );

  public searchCompaniesRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromAuthentication.searchCompaniesRequest),
      switchMap(({ filter, pageRequest }) => 
        this._authenticationService.searchCompanies(filter, pageRequest)
          .pipe(
            mergeMap((page: Page<Tenant>) => of(fromAuthentication.searchCompaniesRequestSuccess({ page: page }))),
            catchError((error: any) => of(fromAuthentication.searchCompaniesRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching companies!'
              } as ResponseMessage
            })))
          )
      )
    )
  );
}
