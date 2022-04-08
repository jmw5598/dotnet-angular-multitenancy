import { Injectable } from "@angular/core";
import { catchError, mergeMap, of, switchMap } from "rxjs";
import { Actions, createEffect, ofType } from "@ngrx/effects";

import * as fromUserAccounts from './user-accounts.actions';
import { ResponseMessage, ResponseStatus, Page } from "@xyz/office/modules/core/models";
import { UserDto } from '@xyz/office/modules/core/dtos';
import { UsersService } from "@xyz/office/modules/core/services/users.service";

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
            mergeMap((page: Page<UserDto>) => of(fromUserAccounts.searchUserAccountsRequestSuccess({ page: page }))),
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
}
