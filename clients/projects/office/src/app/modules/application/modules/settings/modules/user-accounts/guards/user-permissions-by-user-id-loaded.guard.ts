import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import * as fromUserAccounts from '../store';
import { UserPermission } from '@xyz/office/modules/core/entities';

@Injectable({
  providedIn: 'root'
})
export class UserPermissionsByUserIdLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const userId: string = route.params['userId'] || '';
    return this._getUserPermissionsByUserIdFromStoreOrApi(userId)
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getUserPermissionsByUserIdFromStoreOrApi(userId: string): Observable<UserPermission[] | null> {
    return this._store.select(fromUserAccounts.selectSelectedUsersPermissions)
      .pipe(
        tap(permissions => {
          if (!permissions) {
            this._store.dispatch(
              fromUserAccounts.getUserPermissionByUserIdRequest({ userId: userId })
            );
          }
        }),
        filter(permissions => !!permissions),
        take(1)
      );
  }
}
