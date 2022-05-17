import { Location } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { User, UserModulePermission, UserPermission } from '@xyz/office/modules/core/entities';
import { ResponseStatus, UserAccount } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';
import { NzMessageService } from 'ng-zorro-antd/message';
import { filter, Observable, Subject, take, takeUntil } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { mapAssignableModulePermissionsToUserModulePermissions, userAccountFormToUserAccount } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsCreateComponent implements OnDestroy {
  private _subscriptionSubject: Subject<any> = new Subject<any>();

  public createUserAccountForm!: FormGroup;

  constructor(
    private _location: Location,
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _userValidators: UserValidators,
    private _messageService: NzMessageService
  ) {
    this._store.select(fromUserAccounts.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        this.createUserAccountForm = buildUserAccountForm(this._formBuilder, this._userValidators, userModulerPermissions);
      });
  }

  public onCreateUserAccount(formValue: any, shouldReturn: boolean): void {
    if (this.createUserAccountForm.invalid) return;

    const userAccount = userAccountFormToUserAccount(formValue);
    removeEmptyKeys(userAccount);

    this._store.dispatch(fromUserAccounts.createUserAccountRequest({ userAccount: userAccount }));

    this._store.select(fromUserAccounts.selectCreateUserAccountResponseMessage)
      .pipe(
        filter(message => !!message),
        take(1)
      )
      .subscribe(message => {
        if (message?.status === ResponseStatus.SUCCESS) {
          this.createUserAccountForm.reset();
          this._messageService.success(message?.message || 'Success!')
          if (shouldReturn) {
            this._location.back();
          }
        } else {
          this._messageService.error(message?.message || 'Error!')
        }
        this._store.dispatch(fromUserAccounts.setCreateUserAccountRequestResponseMessage({ message: null } ))
      });
  }

  ngOnDestroy(): void {
    this._subscriptionSubject.next(null);
    this._subscriptionSubject.complete();
  }
}