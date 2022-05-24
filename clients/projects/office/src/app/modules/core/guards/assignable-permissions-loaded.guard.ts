import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromPermissions from '../../../store/permissions';
import { ModulePermission } from '@xyz/office/modules/core/entities';

@Injectable({
  providedIn: 'root'
})
export class AssignablePermissionsLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromPermissions.PermissionsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getAssignablePermissionsFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getAssignablePermissionsFromStoreOrApi(): Observable<ModulePermission[] | null> {
    return this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(
        tap(permissions => {
          if (!permissions) {
            this._store.dispatch(fromPermissions.getAssignableModulePermissionsRequest());
          }
        }),
        filter(permissions => !!permissions),
        take(1)
      );
  }
}
