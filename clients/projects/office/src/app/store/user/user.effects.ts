import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import * as fromUser from './user.actions';
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";
import { UsersService } from "@xyz/office/modules/core/services/tenants";

@Injectable()
export class UserEffects {
  constructor(
    private _actions: Actions,
    private _usersService: UsersService
  ) { }

  public getUserSettingsRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromUser.getUserSettingsRequest),
      switchMap(() => this._usersService.getUserSettings()
        .pipe(
          mergeMap(settings => of(fromUser.getUserSettingsRequestSuccess({ settings: settings }))),
          catchError(error => {
            return of(fromUser.getUserSettingsRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error || 'Error getting user settings!'
            } as ResponseMessage}))
          }))   
        )
      )
    );

  public getUserPermissionsRequest$ = createEffect(() => this._actions
    .pipe(
      ofType(fromUser.getUserPermissionsRequest),
      switchMap(() => this._usersService.getUserPermissions()
        .pipe(
          mergeMap(userModulePermissions => of(fromUser.getUserPermissionsRequestSuccess({ userModulePermissions: userModulePermissions }))),
          catchError(error => {
            return of(fromUser.getUserPermissionsRequestFailure({ message: {
              status: ResponseStatus.ERROR,
              message: error?.error || 'Error getting user permissions!'
            } as ResponseMessage}))
          }))   
        )
      )
    );
}
