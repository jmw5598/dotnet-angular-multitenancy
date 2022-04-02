import { Pipe, PipeTransform } from '@angular/core';

import { PermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanRead'
})
export class XyzCanReadPipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: PermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canRead || false
      : false;
  }
}
