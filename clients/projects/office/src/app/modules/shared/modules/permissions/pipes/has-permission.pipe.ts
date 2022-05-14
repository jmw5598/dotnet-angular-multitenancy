import { Pipe, PipeTransform } from '@angular/core';

import { PermissionNames, UserModulesAndPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzHasPermission'
})
export class XyzHasPermissionPipe implements PipeTransform {
  public transform(
    userModulePermissionsMap: UserModulesAndPermissionsMap | null, 
    permissionName: PermissionNames | null | undefined
  ): boolean {
    return userModulePermissionsMap 
      && permissionName 
      && userModulePermissionsMap?.permissions?.hasOwnProperty(permissionName) || false;
  }
}
