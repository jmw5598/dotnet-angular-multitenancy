import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import { UserModulesAndPermissionsMap } from '../../models';

import * as fromUser from '@xyz/office/store/user';

@Injectable({
  providedIn: 'root'
})
export class UserModulePermissionsLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromUser.UserState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getUserSettingsFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getUserSettingsFromStoreOrApi(): Observable<UserModulesAndPermissionsMap | null> {
    return this._store.select(fromUser.selectUserModulePermissionsMap)
      .pipe(
        tap(permissions => {
          if (!permissions) {
            this._store.dispatch(fromUser.getUserPermissionsRequest());
          }
        }),
        filter(permissions => !!permissions),
        take(1)
      );
  }
}
