import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import { PlansService } from "@xyz/office/modules/core/services";

import * as fromUser from './user.actions';
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";

@Injectable()
export class UserEffects {
  constructor(
    private _actions: Actions
  ) { }

  // @TODO
}