import { Pipe, PipeTransform } from '@angular/core';
import { ModulePermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzHasModulePermission'
})
export class XyzHasModulePermissionPipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: ModulePermissionType): boolean {
    return userPermissionsMap ? userPermissionsMap?.hasOwnProperty(type) : false
  }
}
