import { Pipe, PipeTransform } from '@angular/core';

import { PermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanCreate'
})
export class XyzCanCreatePipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: PermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canCreate || false
      : false;
  }
}
