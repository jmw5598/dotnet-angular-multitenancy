import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AbstractControl, ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { Permission, UserPermission } from '@xyz/office/modules/core/entities';
import { UserPermissionGroup } from '@xyz/office/modules/core/models';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable, Observer } from 'rxjs';

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

  // @TODO clean up
  loading = false;
  avatarUrl?: string;

  beforeUpload = (file: NzUploadFile, _fileList: NzUploadFile[]): Observable<boolean> =>
    new Observable((observer: Observer<boolean>) => {
      const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
      if (!isJpgOrPng) {
        console.log('You can only upload JPG file!')
        observer.complete();
        return;
      }
      const isLt2M = file.size! / 1024 / 1024 < 2;
      if (!isLt2M) {
        console.log('Image must smaller than 2MB!');
        observer.complete();
        return;
      }
      observer.next(isJpgOrPng && isLt2M);
      observer.complete();
    });

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  handleChange(info: { file: NzUploadFile }): void {
    switch (info.file.status) {
      case 'uploading':
        this.loading = true;
        break;
      case 'done':
        // Get this url from response in real world.
        this.getBase64(info.file!.originFileObj!, (img: string) => {
          this.loading = false;
          this.avatarUrl = img;
        });
        break;
      case 'error':
        console.log('Network error');
        this.loading = false;
        break;
    }
  }
}
