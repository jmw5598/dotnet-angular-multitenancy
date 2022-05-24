import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { take } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { ModulePermission, TemplateModulePermission } from '@xyz/office/modules/core/entities';

import { buildTemplateModulePermissionNameForm } from '../../components/template-module-permission-name-create-form/template-module-permission-name-create-form.builder';
import { mapAssignableModulePermissionsToTemplateModulePermissions } from '../../utils';

import * as fromPermissions from '@xyz/office/store/permissions';
import * as fromSecurityPermissions from '../../store';

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
    private _formBuilder: FormBuilder,
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
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

}
