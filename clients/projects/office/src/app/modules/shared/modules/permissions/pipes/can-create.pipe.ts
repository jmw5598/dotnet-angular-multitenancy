import { Pipe, PipeTransform } from '@angular/core';

import { ModulePermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanCreate'
})
export class XyzCanCreatePipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: ModulePermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canCreate || false
      : false;
  }
}
