import { Pipe, PipeTransform } from '@angular/core';

import { ModulePermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanUpdate'
})
export class XyzCanUpdatePipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: ModulePermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canUpdate || false
      : false;
  }
}
