import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, Input, EventEmitter, Output } from '@angular/core';
import { AbstractControl, ControlContainer, FormArray, FormGroup } from '@angular/forms';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities/tenants';
import { EnvironmentService } from '@xyz/office/modules/core/services';
import { NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable, Observer } from 'rxjs';

@Component({
  selector: 'xyz-user-account-create-form',
  templateUrl: './user-account-create-form.component.html',
  styleUrls: ['./user-account-create-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountCreateFormComponent implements OnInit {
  @Input()
  public templateModulePermissionNames: TemplateModulePermissionName[] | null = [];

  @Output()
  public selectTemplateModulePermissionName: EventEmitter<TemplateModulePermissionName | null> = 
    new EventEmitter<TemplateModulePermissionName | null>();

  public userAccountForm!: FormGroup;

  public isLoadingTemplate: boolean = false;

  constructor(
    private _controlContainer: ControlContainer,
    private _environmentService: EnvironmentService,
    private _changeDetectorRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.userAccountForm = this._controlContainer.control as FormGroup;
  }

  public get uploadAvatarUrl(): string {
    return `${this._environmentService.getBaseApiUrl()}/files/avatar`;
  }

  public get userModulePermissions(): FormArray {
    return this.userAccountForm.get('userModulePermissions') as FormArray;
  }

  public getUserPermissionsFormArray(control: AbstractControl): FormArray {
    const formGroup: FormGroup = control as FormGroup;
    return formGroup.get('userPermissions') as FormArray;
  }

  public onApplyTemplateModulerPermissionName(templateModulePermissionName: TemplateModulePermissionName | null): void {
    this.isLoadingTemplate = true;
    this.selectTemplateModulePermissionName.emit(templateModulePermissionName);
    setTimeout(() => {
      this.isLoadingTemplate = false;
      this._changeDetectorRef.markForCheck();
    }, 500);
  }

  public onUserModulePermissionAccessChange(event: any, control: AbstractControl): void {
    control?.patchValue({
      canCreateAll: event,
      canReadAll: event,
      canUpdateAll: event,
      canDeleteAll: event
    });
  }

  public onUserModulePermissionCanCreateAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormArray: FormArray = formGroup?.get('userPermissions') as FormArray;

    if (userPermissionFormArray) {
      userPermissionFormArray?.controls?.forEach(control => {
        const childUserPermissionFormGroup: FormGroup = control as FormGroup;
        childUserPermissionFormGroup?.patchValue({
          canCreate: event
        })
      });
    }
  }

  public onUserModulePermissionCanReadAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormArray: FormArray = formGroup?.get('userPermissions') as FormArray;

    if (userPermissionFormArray) {
      userPermissionFormArray?.controls?.forEach(control => {
        const userPermissionFormGroup: FormGroup = control as FormGroup;
        userPermissionFormGroup?.patchValue({
          canRead: event
        })
      });
    }
  }

  public onUserModulePermissionCanUpdateAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormArray: FormArray = formGroup?.get('userPermissions') as FormArray;

    if (userPermissionFormArray) {
      userPermissionFormArray?.controls?.forEach(control => {
        const userPermissionFormGroup: FormGroup = control as FormGroup;
        userPermissionFormGroup?.patchValue({
          canUpdate: event
        })
      });
    }
  }

  public onUserModulePermissionCanDeleteAllChange(event: any, control: AbstractControl): void {
    const formGroup = control as FormGroup;
    const userPermissionFormArray: FormArray = formGroup?.get('userPermissions') as FormArray;

    if (userPermissionFormArray) {
      userPermissionFormArray?.controls?.forEach(control => {
        const userPermissionFormGroup: FormGroup = control as FormGroup;
        userPermissionFormGroup?.patchValue({
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
