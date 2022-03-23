import { Store } from '@ngrx/store';

import * as fromAuthentication from '@xyz/office/modules/authentication/store';
import { AuthenticationService } from '@xyz/office/modules/authentication/services/authentication.service';
import { AuthenticatedUser } from '../models';
import { take } from 'rxjs';

export function authenticatedUserInitializer(
    store: Store<fromAuthentication.AuthenticationState>, 
    authenticationSerivce: AuthenticationService) {
  
  const user: AuthenticatedUser | null = authenticationSerivce.getCachedAuthenticatedUser();

  return () => new Promise<boolean>(resolve => {
    if (user) {
      store.dispatch(fromAuthentication.loginUserSuccess({ authenticatedUser: user }));
      // store.dispatch(fromAuthentication.refreshToken());
    } else {
      store.dispatch(fromAuthentication.setAuthenticatedUser({ authenticatedUser: null }))
    }
    store.select(fromAuthentication.selectAuthenticatedUser)
      .pipe(take(1))
      .subscribe(user => resolve(true))    
  });
};
