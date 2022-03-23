import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { AuthenticatedStatus, AuthenticatedUser, Credentials, PasswordReset, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { EnvironmentService } from '@xyz/office/modules/core/services';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
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

}
