import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { catchError, combineLatest, filter, mergeMap, Observable, of, switchMap, take, tap } from 'rxjs';
import { Store } from '@ngrx/store';

import { defaultDateRangeQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { Page } from '@xyz/office/modules/core/models';
import { BillingInvoice } from '@xyz/office/modules/core/entities/multitenancy';

import * as fromBilling from '../store/billing';

import { defaultBillingInvoicesSort } from '../constants/sorts.defaults';

@Injectable({
  providedIn: 'root'
})
export class InitialBillingInvoicesSearchLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromBilling.BillingState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getUserAccountsPageFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getUserAccountsPageFromStoreOrApi(): Observable<Page<BillingInvoice> | null> {

    return combineLatest([
        this._store.select(fromBilling.selectBillingInvoicesSearchFilter),
        this._store.select(fromBilling.selectBillingInvoicesPage)
      ])
      .pipe(tap(([filter, page]) => {
        if (!page) {
          this._store.dispatch(fromBilling.searchBillingInvoicesRequest({
            filter: filter || defaultDateRangeQuerySearchFilter,
            pageRequest: {
              ...defaultPageRequest,
              sort: {
                ...defaultBillingInvoicesSort
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
