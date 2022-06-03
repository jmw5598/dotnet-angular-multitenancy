import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { catchError, combineLatest, filter, mergeMap, Observable, of, switchMap, take, tap } from 'rxjs';

import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';
import { Page, SortDirection } from '@xyz/office/modules/core/models';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';

import * as fromSecurityPermissions from '../store';
import { defaultSecurityPermissionsSort } from '../constants/sort.defaults';

@Injectable({
  providedIn: 'root'
})
export class InitialTemplateModulePermissionNamesSearchLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getTemplateModulePermissionNamesPageFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getTemplateModulePermissionNamesPageFromStoreOrApi(): Observable<Page<TemplateModulePermissionName> | null> {

    return combineLatest([
        this._store.select(fromSecurityPermissions.selectTemplateModulePermissionSearchFilter),
        this._store.select(fromSecurityPermissions.selectTemplateModulePermissionNamesPage)
      ])
      .pipe(tap(([filter, page]) => {
        if (!page) {
          this._store.dispatch(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest({
            filter: filter || defaultBasicQuerySearchFilter,
            pageRequest: {
              ...defaultPageRequest,
              sort: {
                ...defaultSecurityPermissionsSort
              }
            }
          }));
        }
      }),
      filter(([filter, page]) => !!page),
      mergeMap(([filter, page]) => of(page)),
      take(1));
  }
}
