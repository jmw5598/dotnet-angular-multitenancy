import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ModulePermission, TemplateModulePermissionName } from '@xyz/office/modules/core/entities';
import { Page, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { PermissionsService } from '@xyz/office/modules/core/services';
import { catchError, exhaustMap, mergeMap, of, switchMap } from 'rxjs';

import * as fromSecurityPermissions from './security-permissions.actions';

@Injectable()
export class SecurityPermissionsEffects {
  constructor(
    private _actions: Actions,
    private _permissionsService: PermissionsService
  ) { }

  public createTemplateModulePermissionNameRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromSecurityPermissions.createTemplateModulePermissionNameRequest),
      exhaustMap(({ templateModulePermissionName }) => 
        this._permissionsService.createTemplateModulePermissionName(templateModulePermissionName)
          .pipe(
            mergeMap((templateModulePermission) => of(fromSecurityPermissions.createTemplateModulePermissionNameRequestSuccess({
              message: {
                status: ResponseStatus.SUCCESS,
                message: 'Successfully created permission template!'
              } as ResponseMessage
            }))),
            catchError((error: any) => of(fromSecurityPermissions.createTemplateModulePermissionNameRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error?.error || 'Error creating permission template!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public searchTemplateModulePermissionNamesRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest),
      switchMap(({ filter, pageRequest }) => 
        this._permissionsService.searchTemplateModulePermissionNames(filter, pageRequest)
          .pipe(
            mergeMap((page: Page<TemplateModulePermissionName>) => of(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequestSuccess({ page: page }))),
            catchError((error: any)=> of(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching templates!'
              } as ResponseMessage
            })))
          )
      )
    )
  );
}