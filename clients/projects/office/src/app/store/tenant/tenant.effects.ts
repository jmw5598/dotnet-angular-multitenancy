import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";

import { TenantsService } from "@xyz/office/modules/core/services";
import { catchError, mergeMap, of, switchMap } from "rxjs";

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
}
