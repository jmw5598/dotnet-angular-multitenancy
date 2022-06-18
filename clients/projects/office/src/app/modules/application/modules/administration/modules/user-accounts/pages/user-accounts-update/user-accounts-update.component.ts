import { Location } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { TemplateModulePermissionName, UserModulePermission } from '@xyz/office/modules/core/entities/tenants';
import { ResponseStatus, UserAccount } from '@xyz/office/modules/core/models';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';
import { NzMessageService } from 'ng-zorro-antd/message';
import { filter, Observable, of, skip, Subject, take, takeUntil } from 'rxjs';
import { buildUserAccountUpdateForm } from '../../components/user-account-update-form/user-account-update-form.builder';

import * as fromUserAccounts from '../../store';
import * as fromPermissions from '@xyz/office/store/permissions';

import { mapAssignableModulePermissionsToUserModulePermissions, templateModulerPermissionsToUserModulerPermissions, userAccountFormToUserAccount } from '../../utils';

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
  public templateModulePermissionNames$!: Observable<TemplateModulePermissionName[] | null>;

  constructor(
    private _location: Location,
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _messageService: NzMessageService
  ) {
    this._initializeForm();
    this._selectState();
  }


  ngOnInit(): void {
    this._listenForSelectedUserAccountChanges();
  }


  public onUpdateUserAccount(formValue: any): void {
    if (this.updateUserAccountForm.invalid) return;

    const userAccount = userAccountFormToUserAccount(formValue);
    removeEmptyKeys(userAccount);

    this._store.dispatch(fromUserAccounts.updateUserAccountRequest({ 
      userId: userAccount?.user?.id, 
      userAccount: userAccount 
    }));

    this._store.select(fromUserAccounts.selectUpdateUserAccountResponseMessage)
      .pipe(
        filter(message => !!message),
        take(1)
      )
      .subscribe(message => {
        if (message?.status === ResponseStatus.SUCCESS) {
          this._messageService.success(message?.message || 'Success!')
        } else {
          this._messageService.error(message?.message || 'Error!')
        }
        this._store.dispatch(fromUserAccounts.setUpdateUserAccountRequestResponseMessage({ message: null } ));
        this._location.back();
      });
  }


  public onIssuePasswordResetRequest(shouldIssue: boolean): void {
    if (shouldIssue) {
      alert('Issue reset');
    }
  }


  public onTemplateModulePermissionNameSelected(templateModulePermissionName: TemplateModulePermissionName | null): void {
    if (!templateModulePermissionName) {
      this._resetUserModulerPerrmisionsFormArray();
      return;
    }

    this._store.dispatch(
      fromUserAccounts.getTemplateModulerPermissionNameByIdRequest({
        templateModulePermissionNameId: templateModulePermissionName.id
      })
    );

    this._store.select(fromUserAccounts.selectSelectedTemplateModulePermissionName)
      .pipe(skip(1), take(1))
      .subscribe(templateModulePermissionName => {
        const userModulePermissions = templateModulerPermissionsToUserModulerPermissions(
            templateModulePermissionName?.templateModulePermissions || []);
            
        this._patchUserModulePermissionsToForm(userModulePermissions);
      });
  }


  private _patchUserModulePermissionsToForm(userModulePermissions: UserModulePermission[]): void {
    (this.updateUserAccountForm.get('userModulePermissions') as FormArray)
      .controls.forEach((group) => {
        const userModulePermission = userModulePermissions
          .find(ump => ump.modulePermission?.id === group.value.modulePermission.id);

        group.patchValue({
          ...userModulePermission,
          canCreateAll: userModulePermission?.userPermissions?.some(up => up.canCreate) || false,
          canReadAll: userModulePermission?.userPermissions?.some(up => up.canRead) || false,
          canUpdateAll: userModulePermission?.userPermissions?.some(up => up.canUpdate) || false,
          canDeleteAll: userModulePermission?.userPermissions?.some(up => up.canDelete) || false
        }, { emitEvent: false });
      });
  }


  private _resetUserModulerPerrmisionsFormArray(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        const blankFormGroup = buildUserAccountUpdateForm(this._formBuilder, userModulerPermissions);
        const userModulePermissionsFormGroup = blankFormGroup.get('userModulePermissions');

        console.log("reset permissions ", userModulePermissionsFormGroup);
        if ( userModulePermissionsFormGroup) {
          this.updateUserAccountForm
            ?.get('userModulePermissions')
            ?.patchValue([ ...(userModulePermissionsFormGroup.value || []) ]);
        }
      });
  }
  

  private _initializeForm(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        this.updateUserAccountForm = buildUserAccountUpdateForm(this._formBuilder, userModulerPermissions);
      });
  }


  private _selectState(): void {
    this.templateModulePermissionNames$ = this._store.select(fromUserAccounts.selectTemplateModulePermissionNames);
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
          id: selectedUserAccount?.id || null,
          userName: selectedUserAccount?.userName || null
        });
        
        // Patch Profile Details
        this.updateUserAccountForm?.get('profile')?.patchValue({
          id: selectedUserAccount?.profile?.id || null,
          firstName: selectedUserAccount?.profile?.firstName || null,
          lastName: selectedUserAccount?.profile?.lastName || null
        });

        // Patch User Permissions
        this._patchUserModulePermissionsToForm(selectedUserAccount?.userModulePermissions || []);
      });
  }


  ngOnDestroy(): void {
    this._destroy$.next();
    this._destroy$.complete();
    this._store.dispatch(fromUserAccounts.resetSelectedUserAccountStateSlice());
  }
}
