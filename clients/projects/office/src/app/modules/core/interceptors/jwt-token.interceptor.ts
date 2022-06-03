import { Injectable, OnDestroy } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, Observable, BehaviorSubject, Subscription, throwError, switchMap, filter, take, skip, combineLatest } from 'rxjs';
import { Store } from '@ngrx/store';

import { AuthenticatedUser, AuthenticatedStatus, RefreshTokenRequest } from '../models';
import { REQUIRES_AUTHENTICATION } from './context-tokens/requires-authentication.token';

import * as fromAuthentication from '@xyz/office/modules/authentication/store';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor, OnDestroy {
  private _authenticatedUser!: AuthenticatedUser | null;
  private _authenticatedUserSubscription: Subscription;

  private _refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  private _isRefreshing = false;

  constructor(
    private _store: Store<fromAuthentication.AuthenticationState>,
    private _router: Router
  ) {
    this._authenticatedUserSubscription = this._store.select(fromAuthentication.selectAuthenticatedUser)
      .subscribe(authenticatedUser => this._authenticatedUser = authenticatedUser);
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (request.context.get(REQUIRES_AUTHENTICATION) === false) {
      return next.handle(request);
    }

    if (this._authenticatedUser?.status === AuthenticatedStatus.AUTHENTICATED) {
      const accessToken: string | undefined = this._authenticatedUser?.accessToken;
      request = this._addAuthorizationHeader(request, accessToken || '');
    }
    
    return next.handle(request)
      .pipe(
        catchError(error => {
          if (error instanceof HttpErrorResponse && !request.url.includes('auth/login') && error.status === 401) {
            return this._handleAccessTokenRefreshing(request, next);
          } else {
            return throwError(() => error);
          }
        }));;
  }

  private _handleAccessTokenRefreshing(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this._isRefreshing) {
      this._isRefreshing = true;
      this._refreshTokenSubject.next(null);

      this._store.dispatch(fromAuthentication.refreshAccessTokenRequest({
        refreshTokenRequest: {
          accessToken: this._authenticatedUser?.accessToken || '',
          refreshToken: this._authenticatedUser?.refreshToken || ''
        }
      }));
      
      return combineLatest([
        this._store.select(fromAuthentication.selectAuthenticatedUser),
        this._store.select(fromAuthentication.selectRefreshAccessTokenResponseMessage)
      ]).pipe(
        skip(1),
        switchMap(([authenticatedUser, message]) => {
          if (!message) {
            this._handleRefreshAccessTokenSuccess(authenticatedUser);
            return next.handle(this._addAuthorizationHeader(request, authenticatedUser?.accessToken || ''));
          } else {
            this._handleRefreshAccessTokenFailure();
            return throwError(() => new Error(message?.message));
          }
        }),
        catchError((err) => {
          this._handleRefreshAccessTokenFailure();
          return throwError(() => err);
        }));
    }

    return this._refreshTokenSubject.pipe(
      filter(token => token !== null),
      take(1),
      switchMap((token) => next.handle(this._addAuthorizationHeader(request, token)))
    );
  }

  private _handleRefreshAccessTokenSuccess(authenticatedUser: AuthenticatedUser | null): void {
    this._isRefreshing = false;
    this._refreshTokenSubject.next(authenticatedUser?.accessToken);
  }

  private _handleRefreshAccessTokenFailure(): void {
    this._isRefreshing = false;
    this._store.dispatch(fromAuthentication.logoutUserRequest())
    this._store.dispatch(fromAuthentication.setRefreshAccessTokenResponseMessage({ message: null }))
    this._router.navigateByUrl('/auth/logging-out')
  }

  private _addAuthorizationHeader(request: HttpRequest<unknown>, accessToken: string): HttpRequest<unknown> {
    const prefix: string = 'Bearer';
    const authorizationHeaderValue: string = `${prefix} ${accessToken}`;
    return request.clone({
      setHeaders: {
        Authorization: authorizationHeaderValue 
      }
    });
  }
  
  ngOnDestroy() {
    if (this._authenticatedUserSubscription) {
      this._authenticatedUserSubscription.unsubscribe();
    }
  }
}