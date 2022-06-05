import { Inject, Injectable } from '@angular/core';
import { delay, Observable, of } from 'rxjs';
import { HttpClient, HttpContext } from '@angular/common/http';

import { EnvironmentService, ICacheService, CACHE_SERVICE } from '@xyz/office/modules/core/services';
import { CacheKeys } from '../../constants';

import { 
  AuthenticatedUser, 
  Credentials, 
  PasswordReset, 
  ResponseMessage, 
  ResponseStatus,
  Registration,
  RefreshTokenRequest,
  Page,
  PageRequest } from '@xyz/office/modules/core/models';
import { REQUIRES_AUTHENTICATION } from '../../core/interceptors';
import { BasicQuerySearchFilter } from '../../shared/modules/query-search-filter';
import { Tenant } from '../../core/entities';


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

  public register(registration: Registration): Observable<ResponseMessage> {
    return this._http.post<ResponseMessage>(
      `${this._environmentService.getBaseAuthUrl()}/register`,
      registration
    );
  }

  public refreshToken(refreshTokenRequest: RefreshTokenRequest): Observable<AuthenticatedUser> {
    return this._http.post<AuthenticatedUser>(
      `${this._environmentService.getBaseAuthUrl()}/token/refresh`,
      refreshTokenRequest,
      { context: new HttpContext().set(REQUIRES_AUTHENTICATION, false) }
    );
  }

  public searchCompanies(filter: BasicQuerySearchFilter, pageRequest: PageRequest): Observable<Page<Tenant>> {
    const queryParams: {[key: string]: string } = { 
      query: filter?.query || '',
      size: pageRequest.size.toString(),
      index: pageRequest.index.toString(),
      column: pageRequest?.sort?.column?.toString() || '',
      direction: pageRequest?.sort?.direction?.toString() || ''
    };
    return this._http.get<Page<Tenant>>(
      `${this._environmentService.getBaseAuthUrl()}/companies/search`,
      { params: queryParams }
    );
  }

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
