import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import { FilesService } from "@xyz/office/modules/core/services/tenants";

import * as fromFiles from './files.actions';
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";

@Injectable()
export class FilesEffects {
  constructor(
    private _actions: Actions,
    private _filesService: FilesService
  ) { }
}
