import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import { ResponseMessage, ResponseStatus, Page } from "@xyz/office/modules/core/models";
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { UsersService } from "@xyz/office/modules/core/services/users.service";
import { ModulePermission, UserPermission } from "@xyz/office/modules/core/entities";

import * as fromUserAccounts from './user-accounts.actions';

@Injectable()
export class UserAccountsEffects {
  constructor(
    private _actions: Actions,
    private _usersService: UsersService
  ) { }

  public searchUserAccountsRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.searchUserAccountsRequest),
      switchMap(({ pageRequest }) => 
        this._usersService.searchUsers(pageRequest)
          .pipe(
            mergeMap((page: Page<UserAccountDto>) => of(fromUserAccounts.searchUserAccountsRequestSuccess({ page: page }))),
            catchError((error: any)=> of(fromUserAccounts.searchUserAccountsRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching users!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public getAssignablePermissionRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.getAssignableModulePermissionsRequest),
      switchMap(() => 
        this._usersService.getAssignableModulePermission()
          .pipe(
            mergeMap((permissions: ModulePermission[]) => of(fromUserAccounts.getAssignableModulePermissionsRequestSuccess({ permissions: permissions }))),
            catchError((error: any)=> of(fromUserAccounts.getAssignableModulePermissionsRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error searching users!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public createUserAccountRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.createUserAccountRequest),
      switchMap(({ userAccount }) => 
        this._usersService.createUserAccount(userAccount)
          .pipe(
            mergeMap((userDto: UserAccountDto) => of(fromUserAccounts.createUserAccountRequestSuccess({ userDto: userDto }))),
            catchError((error: any)=> of(fromUserAccounts.createUserAccountRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error create new user!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public getUserByUserIdRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.getUserAccountByUserIdRequest),
      switchMap(({ userId }) => 
        this._usersService.getUserByUserId(userId)
          .pipe(
            mergeMap((user: UserAccountDto) => 
              of(fromUserAccounts.getUserAccountByUserIdRequestSuccess({ user: user }))),
            catchError((error: any)=> of(fromUserAccounts.getUserAccountByUserIdRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error getting user!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public getUserPermissionsByUserIdRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.getUserPermissionByUserIdRequest),
      switchMap(({ userId }) => 
        this._usersService.getUserPermissionsByUserId(userId)
          .pipe(
            mergeMap((permissions: UserPermission[]) => 
              of(fromUserAccounts.getUserPermissionByUserIdRequestSuccess({ userPermissions: permissions }))),
            catchError((error: any)=> of(fromUserAccounts.getUserPermissionByUserIdRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error user permissions for user!'
              } as ResponseMessage
            })))
          )
      )
    )
  );
}
