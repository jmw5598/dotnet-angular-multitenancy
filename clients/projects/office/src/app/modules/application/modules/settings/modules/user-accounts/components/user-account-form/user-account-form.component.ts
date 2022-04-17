import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Permission, UserPermission } from '@xyz/office/modules/core/entities';
import { UserPermissionGroup } from '@xyz/office/modules/core/models';
import { XyzDatatableSettings } from '@xyz/office/modules/shared/modules/datatable';

@Component({
  selector: 'xyz-user-account-form',
  templateUrl: './user-account-form.component.html',
  styleUrls: ['./user-account-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountFormComponent implements OnInit {
  private _assignablePermissions: Permission[] | null = null;

  public userPermissionGroups: UserPermissionGroup[] | null = null;

  @Input()
  public set assignablePermissions (permissions: Permission[] | null) {
    this._assignablePermissions = permissions;
    if (permissions?.length) {
      this.userPermissionGroups = this._mapAssignablePermissionsToUserPermissionGroups(permissions);
    } else {
      this.userPermissionGroups = null;
    }
  };

  public get assignablePermissions(): Permission[] | null {
    return this._assignablePermissions;
  }

  public userAccountForm!: FormGroup;

  public tableSettings: XyzDatatableSettings = {
    bordered: true,
    size: 'middle'
  };

  constructor(
    private _controlContainer: ControlContainer
  ) { }

  ngOnInit(): void {
    this.userAccountForm = this._controlContainer.control as FormGroup;
  }

  private _mapAssignablePermissionsToUserPermissionGroups(permissions: Permission[]): UserPermissionGroup[] | null {
    return permissions
      .filter(permissions => !permissions.parentPermission)
      .map(permission => this._rootPermissionToUserPermissionGroup(permission, permissions));
  }

  private _rootPermissionToUserPermissionGroup(permission: Permission, permissions: Permission[]): UserPermissionGroup {
    const childUserPermissions = permissions.filter(p => p?.parentPermission?.id === permission.id)
      .map(p => this._permissionToUserPermission(p));
    
    const rootUserPermission = this._permissionToUserPermission(permission);
    rootUserPermission.childUserPermissions = childUserPermissions;

    return this._userPermissionToUserPermissionGroup(rootUserPermission);
  }

  private _permissionToUserPermission(permission: Permission): UserPermission {
    return {
      permission: permission,
      canCreate: false,
      canRead: false,
      canUpdate: false,
      canDelete: false
    } as UserPermission
  }

  private _userPermissionToUserPermissionGroup(userPermission: UserPermission): UserPermissionGroup {
    return {
      hasAccess: false,
      userPermission: userPermission
    } as UserPermissionGroup;
  }
}
