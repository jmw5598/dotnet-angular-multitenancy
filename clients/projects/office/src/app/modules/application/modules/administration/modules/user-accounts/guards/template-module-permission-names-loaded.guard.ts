import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';

import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import * as fromUserAccounts from '../store';

@Injectable({
  providedIn: 'root'
})
export class TemplateModulePermissionNamesLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getTemplateModulePermissionNamesFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getTemplateModulePermissionNamesFromStoreOrApi(): Observable<TemplateModulePermissionName[] | null> {

    return this._store.select(fromUserAccounts.selectTemplateModulePermissionNames)
      .pipe(tap((templateModulePermissionNames) => {
        if (!templateModulePermissionNames) {
          this._store.dispatch(fromUserAccounts.getAllTemplateModulePermissionNamesRequest());
        }
      }),
      filter((templateModulePermissionNames) => !!templateModulePermissionNames),
      take(1)
    );
  }
}
