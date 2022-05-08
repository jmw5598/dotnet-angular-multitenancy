import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, Observable, of, switchMap } from 'rxjs';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';
import { ModulePermissionType, UserPermissionsMap } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class HasModulePermissionGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _store: Store<fromRoot.RootState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const type: ModulePermissionType = route.data['modulePermissionType'] as ModulePermissionType;
    
    return this._store.select(fromUser.selectUserPermissionsMap)
      .pipe(
        switchMap((permissions: UserPermissionsMap | null) => {
          const hasModulePermission: boolean = permissions ? !!permissions[type] || false : false;

          if (!hasModulePermission) {
            this._router.navigateByUrl('/error/403');
          }

          return of(hasModulePermission);
        }),
        catchError(() => {
          this._router.navigateByUrl('/error/403');
          return of(false);
        })
      );
  }
}
