import { Injectable } from '@angular/core';
import { catchError, mergeMap, of, switchMap } from 'rxjs';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import * as fromAccountInformation from './account-information.actions';

@Injectable()
export class AccountInformationEffects {
  constructor(
    private _actions: Actions
  ) { }
}
