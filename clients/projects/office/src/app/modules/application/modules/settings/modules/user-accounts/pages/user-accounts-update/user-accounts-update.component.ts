import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { UserDto } from '@xyz/office/modules/core/dtos';
import { UserAccount, UserPermissionGroup } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable, of, take } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { flattenUserPermissionGroups, mapAssignablePermissionsToUserPermissionGroups } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-update',
  templateUrl: './user-accounts-update.component.html',
  styleUrls: ['./user-accounts-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsUpdateComponent implements OnInit {
  public updateUserAccountForm!: FormGroup;
  public selectedUserAccount$!: Observable<UserDto>;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _userValidators: UserValidators
  ) {
    this.selectedUserAccount$ = of({ email: 'jmw5598@gmail.com', firstName: 'Jason', lastName: 'White' } as UserDto);

    this._store.select(fromUserAccounts.selectAssignablePermissions)
      .pipe(take(1))
      .subscribe(assignablePermissions => {
        const userPermissionGroups: UserPermissionGroup[] = mapAssignablePermissionsToUserPermissionGroups(assignablePermissions || []) || [];
        this.updateUserAccountForm = buildUserAccountForm(this._formBuilder, this._userValidators, userPermissionGroups);
      });
  }

  ngOnInit(): void {
  }
  


  public onUpdateUserAccount(formValue: any): void {
    if (this.updateUserAccountForm.invalid) return;
    
    const userAccount: UserAccount = {
      user: formValue.user,
      profile: formValue.profile,
      userPermissions: flattenUserPermissionGroups(formValue.userPermissionGroups)
    } as UserAccount;
    
    // this._store.dispatch(fromUserAccounts.createUserAccountRequest({ userAccount: userAccount }));
  }

}
