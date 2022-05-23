import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { Page, UserAccount } from '@xyz/office/modules/core/models';
import { catchError, combineLatest, filter, mergeMap, Observable, of, switchMap, take, tap } from 'rxjs';

import * as fromUserAccounts from '../store';

@Injectable({
  providedIn: 'root'
})
export class InitialUserAccountsSearchLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getUserAccountsPageFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getUserAccountsPageFromStoreOrApi(): Observable<Page<UserAccountDto> | null> {

    return combineLatest([
        this._store.select(fromUserAccounts.selectUserAccountSearchFilter),
        this._store.select(fromUserAccounts.selectUserAccountsPage)
      ])
      .pipe(tap(([filter, page]) => {
        if (!page) {
          this._store.dispatch(fromUserAccounts.searchUserAccountsRequest({
            filter: filter || defaultBasicQuerySearchFilter,
            pageRequest: defaultPageRequest
          }));
        }
      }),
      filter(([filter, page]) => !!page),
      mergeMap(([filter, page]) => of(page)),
      take(1));
  }
}
