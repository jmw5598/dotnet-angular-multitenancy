import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AuthenticatedStatus, AuthenticatedUser, Credentials } from '../../core/models';

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
}
