import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, Observable, of, switchMap } from 'rxjs';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';
import { ModulePermissionNames, UserModulesAndPermissionsMap } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class HasModulePermissionGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _store: Store<fromRoot.RootState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const moduleName: ModulePermissionNames = route.data['requiredModulePermissionName'] as ModulePermissionNames;
    
    return this._store.select(fromUser.selectUserModulePermissionsMap)
      .pipe(
        switchMap((permissions: UserModulesAndPermissionsMap | null) => {
          const hasModulePermission: boolean = permissions ? (permissions?.modules[moduleName]?.hasAccess) || false : false;

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
