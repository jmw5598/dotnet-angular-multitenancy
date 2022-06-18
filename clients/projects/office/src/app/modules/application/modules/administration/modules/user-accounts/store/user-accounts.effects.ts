import { Injectable } from '@angular/core';
import { catchError, mergeMap, of, switchMap } from 'rxjs';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { ResponseMessage, ResponseStatus, Page } from '@xyz/office/modules/core/models';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { TemplateModulePermissionName, UserPermission } from '@xyz/office/modules/core/entities/tenants';
import { PermissionsService, UsersService } from '@xyz/office/modules/core/services/tenants';

import * as fromUserAccounts from './user-accounts.actions';

@Injectable()
export class UserAccountsEffects {
  constructor(
    private _actions: Actions,
    private _usersService: UsersService,
    private _permissionsService: PermissionsService
  ) { }

  public searchUserAccountsRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.searchUserAccountsRequest),
      switchMap(({ filter, pageRequest }) => 
        this._usersService.searchUsers(filter, pageRequest)
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

  public createUserAccountRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.createUserAccountRequest),
      switchMap(({ userAccount }) => 
        this._usersService.createUserAccount(userAccount)
          .pipe(
            mergeMap((userDto: UserAccountDto) => of(fromUserAccounts.createUserAccountRequestSuccess({ 
              message: {
                status: ResponseStatus.SUCCESS,
                message: 'Successfully create new user account!'
              } as ResponseMessage
            }))),
            catchError((error: any) => {
              const message: string = error?.status === 403 
                ? 'Forbidden, you have reached your max allowed user!' 
                : error?.error ? error?.error : 'Error creating new user account!';
              
                return of(fromUserAccounts.createUserAccountRequestFailure({
                message: {
                  status: ResponseStatus.ERROR,
                  message: message
                } as ResponseMessage
              }))
            })
          )
      )
    )
  );

  public updateUserAccountRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.updateUserAccountRequest),
      switchMap(({ userId, userAccount }) => 
        this._usersService.updateUserAccount(userId, userAccount)
          .pipe(
            mergeMap((userDto: UserAccountDto) => of(fromUserAccounts.updateUserAccountRequestSuccess({ 
              message: {
                status: ResponseStatus.SUCCESS,
                message: 'Successfully updated user account!'
              } as ResponseMessage
            }))),
            catchError((error: any)=> of(fromUserAccounts.updateUserAccountRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error updating user account!'
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

  public getAllTemplateModulePermissionNamesRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.getAllTemplateModulePermissionNamesRequest),
      switchMap(() => 
        this._permissionsService.getTemplateModulePermissionNames()
          .pipe(
            mergeMap((templateModulePermissionNames: TemplateModulePermissionName[]) => 
              of(fromUserAccounts
                .getAllTemplateModulePermissionNamesRequestSuccess({
                  templateModulePermissionNames: templateModulePermissionNames
                })
              )
            ),
            catchError((error: any)=> of(fromUserAccounts.getAllTemplateModulePermissionNamesRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error.error || 'Error getting permission templates!'
              } as ResponseMessage
            })))
          )
      )
    )
  );

  public getTemplateModulePermissionNameByIdRequest = createEffect(() => this._actions
    .pipe(
      ofType(fromUserAccounts.getTemplateModulerPermissionNameByIdRequest),
      switchMap(({ templateModulePermissionNameId }) =>
        this._permissionsService.getTemplateModulePermissionNameById(templateModulePermissionNameId)
          .pipe(
            mergeMap((template: TemplateModulePermissionName) => of(
              fromUserAccounts.getTemplateModulerPermissionNameByIdRequestSuccess({ 
                templateModulePermissionName: template 
              })
            )),
            catchError((error: any) => of(fromUserAccounts.getTemplateModulerPermissionNameByIdRequestFailure({
              message: {
                status: ResponseStatus.ERROR,
                message: error?.error || 'Error getting permissions template'
              } as ResponseMessage
            })))
          )
      )
    )
  )
}
