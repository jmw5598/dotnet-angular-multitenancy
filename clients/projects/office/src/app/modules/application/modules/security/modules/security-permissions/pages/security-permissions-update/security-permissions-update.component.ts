import { Location } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { filter, Subject, take } from 'rxjs';

import { NzMessageService } from 'ng-zorro-antd/message';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { TemplateModulePermission, TemplateModulePermissionName } from '@xyz/office/modules/core/entities';
import { ResponseStatus } from '@xyz/office/modules/core/models';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';

import { buildTemplateModulePermissionNameForm } from '../../components/shared/template-module-permission-name-form.builder';
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

  constructor(
    private _location: Location,
    private _formBuilder: FormBuilder,
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>,
    private _messageService: NzMessageService
  ) {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const templateModulerPermissions: TemplateModulePermission[] = 
          mapAssignableModulePermissionsToTemplateModulePermissions(assignableModulePermissions || []) || [];
        
        this.updateTemplateModulePermissionNameForm = 
          buildTemplateModulePermissionNameForm(this._formBuilder, templateModulerPermissions || []);
      });
  }

  ngOnInit(): void {
  }

  public onCreateTempalteModulePermissionName(template: TemplateModulePermissionName, shouldReturn: boolean): void {
    if (this.updateTemplateModulePermissionNameForm.invalid) return;
    removeEmptyKeys(template);

    this._store.dispatch(fromSecurityPermissions.updateTemplateModulePermissionNameRequest({
      templateModulePermissionNameId: template.id,
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
          if (shouldReturn) {
            this._location.back();
          }
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

  ngOnDestroy(): void {
    this._store.dispatch(fromSecurityPermissions.setSelectedTemplateModulePermissionName({ 
      templateModulePermissionName: null
    }));
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
