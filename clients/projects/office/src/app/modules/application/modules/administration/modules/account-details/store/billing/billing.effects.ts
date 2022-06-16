import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import { BillingService } from '@xyz/office/modules/core/services';
import { Page, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { BillingInvoice } from '@xyz/office/modules/core/entities';

import * as fromBilling from './billing.actions';

@Injectable()
export class BillingEffects {
  constructor(
    private _actions: Actions,
    private _billingService: BillingService
  ) { }

  public searchBillingInvoicesRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromBilling.searchBillingInvoicesRequest),
      switchMap(({ filter, pageRequest }) => 
        this._billingService.searchBillingInvoices(filter, pageRequest)
          .pipe(
            mergeMap((page: Page<BillingInvoice>) => of(fromBilling.searchBillingInvoicesRequestSuccess({ page: page }))),
            catchError((error) => of(fromBilling.searchBillingInvoicesRequestFailure({
              message: {
                message: error.error || 'Error searching billing invoices!',
                status: ResponseStatus.ERROR
              } as ResponseMessage
            })))
          )
      )
    )
  );
}
