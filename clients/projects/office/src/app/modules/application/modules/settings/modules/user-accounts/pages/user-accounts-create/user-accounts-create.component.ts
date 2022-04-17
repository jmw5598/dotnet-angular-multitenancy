import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Permission } from '@xyz/office/modules/core/entities';
import { UserPermissionGroup } from '@xyz/office/modules/core/models';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable, take } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { mapAssignablePermissionsToUserPermissionGroups } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsCreateComponent implements OnInit {
  public createUserAccountForm!: FormGroup;

  public assignablePermissions$!: Observable<Permission[] | null>;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) {
    this._store.select(fromUserAccounts.selectAssignablePermissions)
      .pipe(take(1))
      .subscribe(assignablePermissions => {
        const userPermissionGroups: UserPermissionGroup[] = mapAssignablePermissionsToUserPermissionGroups(assignablePermissions || []) || [];
        this.createUserAccountForm = buildUserAccountForm(this._formBuilder, userPermissionGroups);
      });
    
    this.assignablePermissions$ = this._store.select(fromUserAccounts.selectAssignablePermissions);
  }

  ngOnInit(): void {
  }

  public onCreateUserAccount(formValue: any): void {
    console.log("form value is ", formValue);
  }

}
