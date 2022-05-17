import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { UserModulePermission } from '@xyz/office/modules/core/entities';
import { UserAccount } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable, of, Subject, take, takeUntil } from 'rxjs';
import { buildUserAccountForm } from '../../components/user-account-form/user-account-form.builder';

import * as fromUserAccounts from '../../store';
import { mapAssignableModulePermissionsToUserModulePermissions } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-update',
  templateUrl: './user-accounts-update.component.html',
  styleUrls: ['./user-accounts-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsUpdateComponent implements OnInit, OnDestroy {
  private _destroy$: Subject<void> = new Subject<void>();
  public updateUserAccountForm!: FormGroup;

  public selectedUserAccount$!: Observable<UserAccountDto | null>;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _userValidators: UserValidators
  ) {
    this._initializeForm();
    this._selectState();
  }

  ngOnInit(): void {
    this._listenForSelectedUserAccountChanges();
  }
  


  public onUpdateUserAccount(formValue: any): void {
    if (this.updateUserAccountForm.invalid) return;
    
    const userAccount: UserAccount = {
      user: {
        ...formValue.user,
        profile: formValue.profile
      },
      userModulePermissions: formValue.userModulePermissions
      // userPermissions: flattenUserPermissionGroups(formValue.userPermissionGroups)
    } as UserAccount;
    
    // this._store.dispatch(fromUserAccounts.createUserAccountRequest({ userAccount: userAccount }));
  }
  
  private _initializeForm(): void {
    this._store.select(fromUserAccounts.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        this.updateUserAccountForm = buildUserAccountForm(this._formBuilder, this._userValidators, userModulerPermissions);
      });
  }

  private _selectState(): void {
    this.selectedUserAccount$ = this._store.select(fromUserAccounts.selectSelectedUserAccount);
  }

  private _listenForSelectedUserAccountChanges(): void {
    this._store.select(fromUserAccounts.selectSelectedUserAccount)
      .pipe(takeUntil(this._destroy$))
      .subscribe(selectedUserAccount => {
        this.updateUserAccountForm.patchValue({
          // Patch avatarUrl??
        });
        
        // Patch User Details
        this.updateUserAccountForm?.get('user')?.patchValue({
          userName: selectedUserAccount?.userName
        });
        
        // Patch Profile Details
        this.updateUserAccountForm?.get('profile')?.patchValue({
          firstName: selectedUserAccount?.firstName,
          lastName: selectedUserAccount?.lastName
        });

        // Patch User Permissions
        (this.updateUserAccountForm?.get('userModulePermissions') as FormArray)?.controls.forEach(control => {
          const userModulePermissionFormGroup: FormGroup = control as FormGroup;

          const userModulePermission: UserModulePermission | undefined = selectedUserAccount?.userModulePermissions
            ?.find(ump => ump?.modulePermission?.id === userModulePermissionFormGroup?.value?.modulePermission?.id);

          userModulePermissionFormGroup?.patchValue({
            ...userModulePermission,
            canCreateAll: userModulePermission?.userPermissions?.some(up => up.canCreate) || false,
            canReadAll: userModulePermission?.userPermissions?.some(up => up.canRead) || false,
            canUpdateAll: userModulePermission?.userPermissions?.some(up => up.canUpdate) || false,
            canDeleteAll: userModulePermission?.userPermissions?.some(up => up.canDelete) || false
          }, {emitEvent: false});
        });
      });
  }

  ngOnDestroy(): void {
    this._store.dispatch(fromUserAccounts.setSelectedUserAccount({ user: null}))
    this._destroy$.next();
    this._destroy$.complete();
  }
}
