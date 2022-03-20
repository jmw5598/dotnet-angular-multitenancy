import { Injectable, OnDestroy } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { Store } from '@ngrx/store';

import { AuthenticatedUser, AuthenticatedStatus } from '../models';
import * as fromAuthentication from '@xyz/office/modules/authentication/store';
import { REQUIRES_AUTHENTICATION } from './context-tokens/requires-authentication.token';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor, OnDestroy {
  private _authenticatedUser!: AuthenticatedUser | null;
  private _authenticatedUserSubscription: Subscription;

  constructor(private _store: Store<fromAuthentication.AuthenticationState>) {
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
    
    return next.handle(request);
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