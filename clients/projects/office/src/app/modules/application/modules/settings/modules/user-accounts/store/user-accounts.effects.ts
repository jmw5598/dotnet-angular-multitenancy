import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import * as fromUserAccounts from './user-accounts.actions';
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";

@Injectable()
export class UserAccountsEffects {
  constructor(
    private _actions: Actions
  ) { }
}
