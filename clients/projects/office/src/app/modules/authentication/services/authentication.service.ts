import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AuthenticatedStatus, AuthenticatedUser, Credentials, PasswordReset, ResponseMessage, ResponseStatus } from '../../core/models';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  public loginUser(credentials: Credentials): Observable<AuthenticatedUser> {
    return of({
      status: AuthenticatedStatus.AUTHENTICATED,
      accessToken: 'kasjdfkljasld;fasdf',
      refreshToken: 'asjdkfljaskldjflasjdf'
    } as AuthenticatedUser);
  }

  public requestPasswordReset(request: PasswordReset): Observable<ResponseMessage> {
    return of({
      status: ResponseStatus.SUCCESS,
      message: 'Success, please check your email!'
    } as ResponseMessage)
  }
}
