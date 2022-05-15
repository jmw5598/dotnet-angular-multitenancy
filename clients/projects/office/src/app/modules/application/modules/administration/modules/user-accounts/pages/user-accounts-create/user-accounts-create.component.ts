import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { User, UserModulePermission } from '@xyz/office/modules/core/entities';
import { UserAccount } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable, take } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { mapAssignableModulePermissionsToUserModulePermissions } from '../../utils';

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
    this._store.select(fromUserAccounts.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        this.createUserAccountForm = buildUserAccountForm(this._formBuilder, this._userValidators, userModulerPermissions);
      });
  }

  ngOnInit(): void {
  }

  public onCreateUserAccount(formValue: any): void {
    if (this.createUserAccountForm.invalid) return;
    console.log("formValue is ", formValue);
    const userAccount: UserAccount = {
      user: {
        ...formValue.user,
        profile: formValue.profile
      } as User,
      // userPermissions: flattenUserPermissionGroups(formValue.userPermissionGroups)
      // could filter out non checkted gorups by adding fitler before flatmap with (group => group.hasAccess)
      // userPermissions: formValue.userPermissionMod?.flatMap((upg: any) => upg.userPermission)
      // userModulePermissions: formValue.userModulePermissions
    } as UserAccount;

    console.log("update form value is ", userAccount, formValue);
    
    // this._store.dispatch(fromUserAccounts.createUserAccountRequest({ userAccount: userAccount }));
  }
}
