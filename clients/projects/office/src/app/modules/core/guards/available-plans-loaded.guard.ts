import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { catchError, filter, Observable, of, switchMap, take, tap } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromRoot from '@xyz/office/store';
import { Plan } from '../entities';
import * as fromPlans from '@xyz/office/store/plans';

@Injectable({
  providedIn: 'root'
})
export class AvailablePlansLoadedGuard implements CanActivate {
  constructor(
    private _store: Store<fromRoot.RootState>
  ) { }

  public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this._getAvailablePlansFromStoreOrApi()
      .pipe(
        switchMap(() => of(true)),
        catchError(() => of(false))
      );
  }
  
  private _getAvailablePlansFromStoreOrApi(): Observable<Plan[] | null> {
    return this._store.select(fromPlans.selectAvailablePlans)
      .pipe(
        tap(availablePlans => {
          if (!availablePlans) {
            this._store.dispatch(fromPlans.getPlansRequest());
          }
        }),
        filter(availablePlans => !!availablePlans),
        take(1)
      );
  }
}
