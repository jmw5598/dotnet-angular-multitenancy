import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { AuthenticatedUser, Credentials, PasswordReset, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { EnvironmentService, ICacheService, CACHE_SERVICE } from '@xyz/office/modules/core/services';
import { CacheKeys } from '../../constants';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient,
    @Inject(CACHE_SERVICE)
    public _cacheService: ICacheService
  ) { }

  public loginUser(credentials: Credentials): Observable<AuthenticatedUser> {
    // return of({
    //   status: AuthenticatedStatus.AUTHENTICATED,
    //   accessToken: 'kasjdfkljasld;fasdf',
    //   refreshToken: 'asjdkfljaskldjflasjdf'
    // } as AuthenticatedUser);

    return this._http.post<AuthenticatedUser>(
      `${this._environmentService.getBaseAuthUrl()}/login`, 
      credentials
    );
  }

  public requestPasswordReset(request: PasswordReset): Observable<ResponseMessage> {
    return of({
      status: ResponseStatus.SUCCESS,
      message: 'Success, please check your email!'
    } as ResponseMessage)
  }

  // Change Password

  public getCachedAuthenticatedUser(): AuthenticatedUser | null {
    return this._cacheService.getItem(CacheKeys.AUTHENTICATED_USER);
  }

  public cacheAuthenticatedUser(user: AuthenticatedUser): void {
    this._cacheService.setItem(CacheKeys.AUTHENTICATED_USER, user);
  }

  public removeCachedAuthenticatedUser(): void {
    this._cacheService.removeItem(CacheKeys.AUTHENTICATED_USER);
  }
}
