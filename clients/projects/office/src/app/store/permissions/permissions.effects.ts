import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, mergeMap, of, switchMap } from "rxjs";

import { PermissionsService } from "@xyz/office/modules/core/services/tenants";
import { ResponseMessage, ResponseStatus } from "@xyz/office/modules/core/models";
import { ModulePermission } from "@xyz/office/modules/core/entities/tenants";

import * as fromPermissions from './permissions.actions';

@Injectable()
export class PermissionsEffects {
  constructor(
    private _actions: Actions,
    private _permissionsService: PermissionsService
  ) { }

  public getAssignablePermissionRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromPermissions.getAssignableModulePermissionsRequest),
      switchMap(() => 
        this._permissionsService.getAssignableModulePermission()
          .pipe(
            mergeMap((permissions: ModulePermission[]) => of(fromPermissions.getAssignableModulePermissionsRequestSuccess({ permissions: permissions }))),
            catchError((error: any)=> of(fromPermissions.getAssignableModulePermissionsRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching users!'
              } as ResponseMessage
            })))
          )
      )
    )
  );
}
