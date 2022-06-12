import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';

import { Store } from '@ngrx/store';

import { TenantStatistics } from '@xyz/office/modules/core/models';

import * as fromAccountDetails from '../store/account-details';

@Injectable({
  providedIn: 'root'
})
export class TenantStatisticsLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromAccountDetails.AccountDetailsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getTenantStatisticsFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getTenantStatisticsFromStoreOrApi(): Observable<TenantStatistics | null> {
    return this._store.select(fromAccountDetails.selectTenantStatistics)
      .pipe(tap((tenantStatistics) => {
        if (!tenantStatistics) {
          this._store.dispatch(fromAccountDetails.getTenantStatisticsRequest());
        }
      }),
      filter((tenantStatistics) => !!tenantStatistics),
      take(1)
    );
  }
}
