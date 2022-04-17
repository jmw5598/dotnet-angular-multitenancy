import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AbstractControl, ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { Permission, UserPermission } from '@xyz/office/modules/core/entities';
import { UserPermissionGroup } from '@xyz/office/modules/core/models';

@Component({
  selector: 'xyz-user-account-form',
  templateUrl: './user-account-form.component.html',
  styleUrls: ['./user-account-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountFormComponent implements OnInit {
  public userAccountForm!: FormGroup;

  constructor(
    private _controlContainer: ControlContainer
  ) { }

  ngOnInit(): void {
    this.userAccountForm = this._controlContainer.control as FormGroup;
  }

  public get userPermissionGroups(): FormArray {
    return this.userAccountForm.get('userPermissionGroups') as FormArray;
  }

  public getChildPermissionsFormArray(control: AbstractControl): FormArray {
    const formGroup: FormGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup.get('userPermission') as FormGroup;
    return userPermissionFormGroup.get('childUserPermissions') as FormArray;
  }

  public onRootPermissionModuleChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup?.get('userPermission') as FormGroup;
    if (userPermissionFormGroup) {
      userPermissionFormGroup?.patchValue({
        canCreate: event,
        canRead: event,
        canUpdate: event,
        canDelete: event
      });
    }
  }

  public onRootPermissionModuleCanCreateChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup?.get('userPermission') as FormGroup;
    const childUserPermissionsFormArray: FormArray = userPermissionFormGroup?.get('childUserPermissions') as FormArray;

    if (childUserPermissionsFormArray) {
      childUserPermissionsFormArray?.controls?.forEach(control => {
        const childUserPermissionFormGroup: FormGroup = control as FormGroup;
        childUserPermissionFormGroup?.patchValue({
          canCreate: event
        })
      });
    }
  }

  public onRootPermissionModuleCanReadChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup?.get('userPermission') as FormGroup;
    const childUserPermissionsFormArray: FormArray = userPermissionFormGroup?.get('childUserPermissions') as FormArray;

    if (childUserPermissionsFormArray) {
      childUserPermissionsFormArray?.controls?.forEach(control => {
        const childUserPermissionFormGroup: FormGroup = control as FormGroup;
        childUserPermissionFormGroup?.patchValue({
          canRead: event
        })
      });
    }
  }

  public onRootPermissionModuleCanUpdateChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup?.get('userPermission') as FormGroup;
    const childUserPermissionsFormArray: FormArray = userPermissionFormGroup?.get('childUserPermissions') as FormArray;

    if (childUserPermissionsFormArray) {
      childUserPermissionsFormArray?.controls?.forEach(control => {
        const childUserPermissionFormGroup: FormGroup = control as FormGroup;
        childUserPermissionFormGroup?.patchValue({
          canUpdate: event
        })
      });
    }
  }

  public onRootPermissionModuleCanDeleteChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormGroup: FormGroup = formGroup?.get('userPermission') as FormGroup;
    const childUserPermissionsFormArray: FormArray = userPermissionFormGroup?.get('childUserPermissions') as FormArray;

    if (childUserPermissionsFormArray) {
      childUserPermissionsFormArray?.controls?.forEach(control => {
        const childUserPermissionFormGroup: FormGroup = control as FormGroup;
        childUserPermissionFormGroup?.patchValue({
          canDelete: event
        })
      });
    }
  }
}
