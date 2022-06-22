import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';

import { TenantsService } from '@xyz/office/modules/core/services/multitenancy';
import { catchError, exhaustMap, mergeMap, of, switchMap } from 'rxjs';

import * as fromTenants from './tenant.actions';

@Injectable()
export class TenantEffects {
  constructor(
    private _actions: Actions,
    private _tenantsService: TenantsService
  ) { }

  public getTenantFromSubdomain = createEffect(() => this._actions
    .pipe(
      ofType(fromTenants.getTenantFromSubdomainRequest),
      switchMap(({ subdomain }) => this._tenantsService.findTenantBySubdomain(subdomain)
        .pipe(
          mergeMap(tenant => of(fromTenants.getTenantFromSubdomainRequestSuccess({ tenant: tenant }))),
          catchError(error => {
            return of(fromTenants.getTenantFromSubdomainRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error || 'Error getting tenant from subdomain'
            } as ResponseMessage }))
          })
        )
      )
    )
  );

  public searchCompaniesRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromTenants.searchCompaniesRequest),
      switchMap(({ filter, pageRequest }) => 
        this._tenantsService.searchCompanies(filter, pageRequest)
          .pipe(
            mergeMap((page: Page<Tenant>) => of(fromTenants.searchCompaniesRequestSuccess({ page: page }))),
            catchError((error: any) => of(fromTenants.searchCompaniesRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching companies!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public registrationRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromTenants.registrationRequest),
      exhaustMap(({ registration }) => this._tenantsService.register(registration)
        .pipe(
          mergeMap(responseMessage => {
            return of(fromTenants.registrationRequestSuccess({ 
              message: responseMessage 
            }));
          }),
          catchError(error => {
            return of(fromTenants.registrationRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error?.message || 'New registration failed. Please try again!'
            } as ResponseMessage }));
          })
        )
      )
    )
  );
}
