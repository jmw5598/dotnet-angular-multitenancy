import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromRoot from '@xyz/office/store';
import * as fromTenant from '@xyz/office/store/tenant';

import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { EnvironmentService } from '../services';

@Injectable({
  providedIn: 'root'
})
export class TenantLoadedFromSubdomainGuard implements CanActivate {
  constructor(
    private _store: Store<fromRoot.RootState>,
    private _environmentService: EnvironmentService
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const subdomain: string = this._environmentService.getSubdomain();
    return this._getTenantFromStoreOrApi(subdomain)
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getTenantFromStoreOrApi(subdomain: string): Observable<Tenant | null> {
    return this._store.select(fromTenant.selectTenant)
      .pipe(
        tap(tenant => {
          if (!tenant) {
            this._store.dispatch(fromTenant.getTenantFromSubdomainRequest({ subdomain: subdomain }));
          }
        }),
        filter(tenant => !!tenant),
        take(1)
      );
  }
}
