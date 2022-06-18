import { Injectable } from '@angular/core';
import { catchError, mergeMap, of, switchMap } from 'rxjs';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { PlansService } from '@xyz/office/modules/core/services/multitenancy';

import * as fromPlans from './plans.actions';
import { ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';

@Injectable()
export class PlansEffects {
  constructor(
    private _actions: Actions,
    private _plansService: PlansService
  ) { }

  public getPlansRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromPlans.getPlansRequest),
      switchMap(() => this._plansService.findAll()
        .pipe(
          mergeMap(plans => of(fromPlans.getPlansRequestSuccess({ plans: plans }))),
          catchError(error => {
            return of(fromPlans.getPlansRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error || 'Error getting available plans!'
            } as ResponseMessage }))
          })
        )
      )
    )
  );
}
