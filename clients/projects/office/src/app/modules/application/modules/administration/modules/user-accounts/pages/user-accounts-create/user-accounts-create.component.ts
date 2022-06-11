import { Location } from '@angular/common';
import { Component, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { filter, Observable, skip, Subject, take } from 'rxjs';

import { Store } from '@ngrx/store';
import { NzMessageService } from 'ng-zorro-antd/message';

import { TemplateModulePermission, TemplateModulePermissionName, User, UserModulePermission, UserPermission } from '@xyz/office/modules/core/entities';
import { ResponseStatus } from '@xyz/office/modules/core/models';
import { UserValidators } from '@xyz/office/modules/core/validators';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';

import { buildUserAccountCreateForm } from '../../components/user-account-create-form/user-account-create-form.builder';

import * as fromUserAccounts from '../../store';
import * as fromPermissions from '@xyz/office/store/permissions';

import { mapAssignableModulePermissionsToUserModulePermissions, templateModulerPermissionsToUserModulerPermissions, userAccountFormToUserAccount } from '../../utils';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsCreateComponent implements OnDestroy {
  private _destroy$: Subject<any> = new Subject<any>();

  public createUserAccountForm!: FormGroup;

  public templateModulePermissionNames$: Observable<TemplateModulePermissionName[] | null>;

  constructor(
    private _location: Location,
    private _formBuilder: FormBuilder,
    private _store: Store<fromUserAccounts.UserAccountsState>,
    private _userValidators: UserValidators,
    private _messageService: NzMessageService
  ) {
    this.templateModulePermissionNames$ = this._store.select(fromUserAccounts.selectTemplateModulePermissionNames);
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        this.createUserAccountForm = buildUserAccountCreateForm(this._formBuilder, this._userValidators, userModulerPermissions);
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
          this._resetCreateUserAccountForm();
          this._messageService.success(message?.message || 'Success!')
          if (shouldReturn) {
            this._location.back();
          }
        } else if (message?.status === ResponseStatus.ERROR) {
          this._messageService.error(message?.message || 'Error!')
        }
        this._store.dispatch(fromUserAccounts.setCreateUserAccountRequestResponseMessage({ message: null } ))
      });
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
    (this.createUserAccountForm.get('userModulePermissions') as FormArray)
      .controls.forEach((group) => {
        const userModulePermission = userModulePermissions
          .find(ump => ump.modulePermission?.id === group.value.modulePermission.id);

        group.patchValue({
          ...userModulePermission
        });
      });
  }


  private _resetCreateUserAccountForm(): void {
    this.createUserAccountForm.reset();
    this._resetUserModulerPerrmisionsFormArray();
  }


  private _resetUserModulerPerrmisionsFormArray(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: UserModulePermission[] = mapAssignableModulePermissionsToUserModulePermissions(assignableModulePermissions || []) || [];
        const blankFormGroup = buildUserAccountCreateForm(this._formBuilder, this._userValidators, userModulerPermissions);
        this.createUserAccountForm.patchValue({ ...blankFormGroup?.value });
      });
  }


  ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
    this._store.dispatch(fromUserAccounts.resetSelectedUserAccountStateSlice());
  }
}
