import { Location } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { filter, Observable, Subject, take, takeUntil } from 'rxjs';

import { NzMessageService } from 'ng-zorro-antd/message';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { TemplateModulePermission, TemplateModulePermissionName } from '@xyz/office/modules/core/entities/tenants';
import { ResponseStatus } from '@xyz/office/modules/core/models';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';

import { buildTemplateModulePermissionNameForm } from '../../components/template-module-permission-name-form/template-module-permission-name-form.builder';
import { mapAssignableModulePermissionsToTemplateModulePermissions } from '../../utils';

import * as fromPermissions from '@xyz/office/store/permissions';
import * as fromSecurityPermissions from '../../store';

@Component({
  selector: 'xyz-security-permissions-update',
  templateUrl: './security-permissions-update.component.html',
  styleUrls: ['./security-permissions-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsUpdateComponent implements OnInit, OnDestroy {
  private _destroy$: Subject<any> = new Subject<any>();
  public updateTemplateModulePermissionNameForm!: FormGroup;

  public selectedTemplateModulePermissionName$!: Observable<TemplateModulePermissionName | null>;

  constructor(
    private _location: Location,
    private _formBuilder: FormBuilder,
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>,
    private _messageService: NzMessageService
  ) {
    this._initializeForm();
    this._selectState();
  }

  ngOnInit(): void {
    this._listenForSelectedUserAccountChanges();
  }

  // @TODO(jason) create type for this form
  public onUpdateTempalteModulePermissionName(template: any): void {
    if (this.updateTemplateModulePermissionNameForm.invalid) return;

    console.log('before stripping undefined/nulls', template);
    removeEmptyKeys(template);

    console.log('template is ', template);

    this._store.dispatch(fromSecurityPermissions.updateTemplateModulePermissionNameRequest({
      templateModulePermissionNameId: template.templateModulePermissionName.id,
      templateModulePermissionName: template 
    }));

    this._store.select(fromSecurityPermissions.selectUpdateTemplateModulePermissionNameResponseMessage)
      .pipe(
        filter(message => !!message),
        take(1)
      )
      .subscribe(message => {
        if (message?.status === ResponseStatus.SUCCESS) {
          this._resetUpdateUserAccountForm();
          this._messageService.success(message?.message || 'Success!')
          this._location.back();
        } else {
          this._messageService.error(message?.message || 'Error!')
        }
        this._store.dispatch(fromSecurityPermissions.setUpdateTemplateModulePermissionNameResponseMessage({ message: null } ))
      });
  }

  private _resetUpdateUserAccountForm(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: TemplateModulePermission[] = mapAssignableModulePermissionsToTemplateModulePermissions(assignableModulePermissions || []) || [];
        const blankFormGroup = buildTemplateModulePermissionNameForm(this._formBuilder, userModulerPermissions);
        this.updateTemplateModulePermissionNameForm.reset();
        this.updateTemplateModulePermissionNameForm.patchValue({ ...blankFormGroup?.value });
      });
  }

  private _initializeForm(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const templateModulerPermissions: TemplateModulePermission[] = 
          mapAssignableModulePermissionsToTemplateModulePermissions(assignableModulePermissions || []) || [];
        
        this.updateTemplateModulePermissionNameForm = 
          buildTemplateModulePermissionNameForm(this._formBuilder, templateModulerPermissions || []);
      });
  }

  private _selectState(): void {
    this.selectedTemplateModulePermissionName$ = this._store.select(fromSecurityPermissions.selectSelectedTemplateModulerPermissionName);
  }

  private _listenForSelectedUserAccountChanges(): void {
    this._store.select(fromSecurityPermissions.selectSelectedTemplateModulerPermissionName)
      .pipe(takeUntil(this._destroy$))
      .subscribe(selectedTemplateModulePermissionName => {

        // Patch Template Moduler Permission Name Details
        this.updateTemplateModulePermissionNameForm?.get('templateModulePermissionName')?.patchValue({
          id: selectedTemplateModulePermissionName?.id || null,
          name: selectedTemplateModulePermissionName?.name || null,
          description: selectedTemplateModulePermissionName?.description || null
        });

        // Patch Template Moduler Permission Name Permissions
        (this.updateTemplateModulePermissionNameForm?.get('templateModulePermissions') as FormArray)?.controls.forEach(control => {
          const templateModulePermissionFormGroup: FormGroup = control as FormGroup;

          const templateModulePermission: TemplateModulePermission | undefined = selectedTemplateModulePermissionName
            ?.templateModulePermissions
            ?.find(ump => ump?.modulePermission?.id === templateModulePermissionFormGroup?.value?.modulePermission?.id);

          templateModulePermissionFormGroup?.patchValue({
            ...templateModulePermission,
            canCreateAll: templateModulePermission?.templatePermissions?.some(up => up.canCreate) || false,
            canReadAll: templateModulePermission?.templatePermissions?.some(up => up.canRead) || false,
            canUpdateAll: templateModulePermission?.templatePermissions?.some(up => up.canUpdate) || false,
            canDeleteAll: templateModulePermission?.templatePermissions?.some(up => up.canDelete) || false
          }, {emitEvent: false});
        });
      });
  }

  ngOnDestroy(): void {
    this._store.dispatch(fromSecurityPermissions.setSelectedTemplateModulePermissionName({ 
      templateModulePermissionName: null
    }));
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
