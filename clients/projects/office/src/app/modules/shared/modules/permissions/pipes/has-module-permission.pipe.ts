import { Pipe, PipeTransform } from '@angular/core';
import { ModulePermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzHasModulePermission'
})
export class XyzHasModulePermissionPipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: ModulePermissionType | null): boolean {
    return userPermissionsMap && type ? userPermissionsMap?.hasOwnProperty(type) : false
  }
}
