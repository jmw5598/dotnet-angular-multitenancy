import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import * as fromBilling from './billing.actions';

@Injectable()
export class BillingEffects {
  constructor(
    private _actions: Actions
  ) { }
}
