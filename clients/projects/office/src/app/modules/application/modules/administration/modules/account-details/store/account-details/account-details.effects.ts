import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import * as fromAccountDetails from './account-details.actions';
import { TenantsService } from "@xyz/office/modules/core/services";
import { ResponseMessage, ResponseStatus, TenantStatistics } from "@xyz/office/modules/core/models";

@Injectable()
export class AccountDetailsEffects {
  constructor(
    private _actions: Actions,
    private _tenantsService: TenantsService
  ) { }

  public getTenantStatisticsRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromAccountDetails.getTenantStatisticsRequest),
      switchMap(() => 
        this._tenantsService.getTenantStatistics()
          .pipe(
            mergeMap((tenantStatistics: TenantStatistics) => 
              of(fromAccountDetails.getTenantStatisticsRequestSuccess({ tenantStatistics: tenantStatistics }))),
            catchError((error: any)=> of(fromAccountDetails.getTenantStatisticsRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error getting tenant statistics!'
              } as ResponseMessage
            })))
          )
      )
    )
  );
}
