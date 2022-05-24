import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AbstractControl, ControlContainer, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-template-module-permission-name-create-form',
  templateUrl: './template-module-permission-name-create-form.component.html',
  styleUrls: ['./template-module-permission-name-create-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TemplateModulePermissionNameCreateFormComponent implements OnInit {
  public templateModulePermissionNameForm!: FormGroup;

  constructor(
    private _controlContainer: ControlContainer
  ) { }

  ngOnInit(): void {
    this.templateModulePermissionNameForm = this._controlContainer?.control as FormGroup;
  }

  public get templateModulePermissions(): FormArray {
    return this.templateModulePermissionNameForm?.get('templateModulePermissions') as FormArray;
  }

  public getTemplatePermissionsFormArray(control: AbstractControl): FormArray {
    const formGroup: FormGroup = control as FormGroup;
    return formGroup.get('templatePermissions') as FormArray;
  }

  public onTemplateModulePermissionAccessChange(event: any, control: AbstractControl): void {
    control?.patchValue({
      canCreateAll: event,
      canReadAll: event,
      canUpdateAll: event,
      canDeleteAll: event
    });
  }

  public onTemplateModulePermissionCanCreateAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const TemplatePermissionFormArray: FormArray = formGroup?.get('templatePermissions') as FormArray;

    if (TemplatePermissionFormArray) {
      TemplatePermissionFormArray?.controls?.forEach(control => {
        const childTemplatePermissionFormGroup: FormGroup = control as FormGroup;
        childTemplatePermissionFormGroup?.patchValue({
          canCreate: event
        })
      });
    }
  }

  public onTemplateModulePermissionCanReadAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const TemplatePermissionFormArray: FormArray = formGroup?.get('templatePermissions') as FormArray;

    if (TemplatePermissionFormArray) {
      TemplatePermissionFormArray?.controls?.forEach(control => {
        const TemplatePermissionFormGroup: FormGroup = control as FormGroup;
        TemplatePermissionFormGroup?.patchValue({
          canRead: event
        })
      });
    }
  }

  public onTemplateModulePermissionCanUpdateAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const TemplatePermissionFormArray: FormArray = formGroup?.get('templatePermissions') as FormArray;

    if (TemplatePermissionFormArray) {
      TemplatePermissionFormArray?.controls?.forEach(control => {
        const TemplatePermissionFormGroup: FormGroup = control as FormGroup;
        TemplatePermissionFormGroup?.patchValue({
          canUpdate: event
        })
      });
    }
  }

  public onTemplateModulePermissionCanDeleteAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const TemplatePermissionFormArray: FormArray = formGroup?.get('templatePermissions') as FormArray;

    if (TemplatePermissionFormArray) {
      TemplatePermissionFormArray?.controls?.forEach(control => {
        const TemplatePermissionFormGroup: FormGroup = control as FormGroup;
        TemplatePermissionFormGroup?.patchValue({
          canDelete: event
        })
      });
    }
  }
}
