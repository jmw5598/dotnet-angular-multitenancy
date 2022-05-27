import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { filter, take } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { TemplateModulePermission, TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

import { buildTemplateModulePermissionNameForm } from '../../components/shared/template-module-permission-name-form.builder';
import { mapAssignableModulePermissionsToTemplateModulePermissions } from '../../utils';

import * as fromPermissions from '@xyz/office/store/permissions';
import * as fromSecurityPermissions from '../../store';
import { ResponseStatus } from '@xyz/office/modules/core/models';
import { Location } from '@angular/common';
import { NzMessageService } from 'ng-zorro-antd/message';
import { removeEmptyKeys } from '@xyz/office/modules/shared/utils';

@Component({
  selector: 'xyz-security-permissions-create',
  templateUrl: './security-permissions-create.component.html',
  styleUrls: ['./security-permissions-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsCreateComponent implements OnInit {
  public createTemplateModulePermissionNameForm!: FormGroup;

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
        
          this.createTemplateModulePermissionNameForm = 
          buildTemplateModulePermissionNameForm(this._formBuilder, templateModulerPermissions || []);
      });
  }

  ngOnInit(): void {
  }

  public onCreateTempalteModulePermissionName(template: TemplateModulePermissionName, shouldReturn: boolean): void {
    if (this.createTemplateModulePermissionNameForm.invalid) return;
    removeEmptyKeys(template);

    this._store.dispatch(fromSecurityPermissions.createTemplateModulePermissionNameRequest({
      templateModulePermissionName: template 
    }));

    this._store.select(fromSecurityPermissions.selectCreateTemplateModulePermissionNameResponseMessage)
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
        } else {
          this._messageService.error(message?.message || 'Error!')
        }
        this._store.dispatch(fromSecurityPermissions.setCreateTemplateModulePermissionNameResponseMessage({ message: null } ))
      });
  }

  private _resetCreateUserAccountForm(): void {
    this._store.select(fromPermissions.selectAssignableModulePermissions)
      .pipe(take(1))
      .subscribe(assignableModulePermissions => {
        const userModulerPermissions: TemplateModulePermission[] = mapAssignableModulePermissionsToTemplateModulePermissions(assignableModulePermissions || []) || [];
        const blankFormGroup = buildTemplateModulePermissionNameForm(this._formBuilder, userModulerPermissions);
        this.createTemplateModulePermissionNameForm.reset();
        this.createTemplateModulePermissionNameForm.patchValue({ ...blankFormGroup?.value });
      });
  }
}
