import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Permission, User } from '@xyz/office/modules/core/entities';
import { UserAccount, UserPermissionGroup } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable, take } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { flattenUserPermissionGroups, mapAssignablePermissionsToUserPermissionGroups } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsCreateComponent implements OnInit {
  public createUserAccountForm!: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _userValidators: UserValidators
  ) {
    this._store.select(fromUserAccounts.selectAssignablePermissions)
      .pipe(take(1))
      .subscribe(assignablePermissions => {
        const userPermissionGroups: UserPermissionGroup[] = mapAssignablePermissionsToUserPermissionGroups(assignablePermissions || []) || [];
        this.createUserAccountForm = buildUserAccountForm(this._formBuilder, this._userValidators, userPermissionGroups);
      });
  }

  ngOnInit(): void {
  }

  public onCreateUserAccount(formValue: any): void {
    if (this.createUserAccountForm.invalid) return;
    
    const userAccount: UserAccount = {
      user: {
        ...formValue.user,
        profile: formValue.profile
      } as User,
      userPermissions: flattenUserPermissionGroups(formValue.userPermissionGroups)
    } as UserAccount;
    
    this._store.dispatch(fromUserAccounts.createUserAccountRequest({ userAccount: userAccount }));
  }
}
