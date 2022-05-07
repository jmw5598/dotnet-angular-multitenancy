import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import * as fromUserAccounts from '../store';

@Injectable({
  providedIn: 'root'
})
export class SelectedUsersAccountLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const userId: string = route.params['userId'] || '';
    return this._getUserAccountByUserIdFromStoreOrApi(userId)
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getUserAccountByUserIdFromStoreOrApi(userId: string): Observable<UserAccountDto | null> {
    return this._store.select(fromUserAccounts.selectSelectedUserAccount)
      .pipe(
        tap(account => {
          if (!account) {
            this._store.dispatch(
              fromUserAccounts.getUserAccountByUserIdRequest({ userId: userId })
            );
          }
        }),
        filter(account => !!account),
        take(1)
      );
  }
}
