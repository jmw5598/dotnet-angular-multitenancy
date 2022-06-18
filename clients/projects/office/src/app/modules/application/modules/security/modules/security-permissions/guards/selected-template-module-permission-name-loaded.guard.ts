import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';

import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities/tenants';

import * as fromSecurityPermissions from '../store';

@Injectable({
  providedIn: 'root'
})
export class SelectedTemplateModulePermissionNameLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const templateModulePermissionNameId: string = route.params['templateModulePermissionNameId'] || '';
    return this._getSelectedTemplateModulePermissionNameFromStoreOrApi(templateModulePermissionNameId)
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getSelectedTemplateModulePermissionNameFromStoreOrApi(templateModulePermissionNameId: string): Observable<TemplateModulePermissionName | null> {
    return this._store.select(fromSecurityPermissions.selectSelectedTemplateModulerPermissionName)
      .pipe(
        tap(template => {
          if (!template) {
            this._store.dispatch(
              fromSecurityPermissions.getTemplateModulerPermissionNameByIdRequest({ 
                templateModulePermissionNameId: templateModulePermissionNameId 
              })
            );
          }
        }),
        filter(template => !!template),
        take(1)
      );
  }
}
