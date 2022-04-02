import { Pipe, PipeTransform } from '@angular/core';

import { ModulePermissionType, UserPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzCanRead'
})
export class XyzCanReadPipe implements PipeTransform {
  public transform(userPermissionsMap: UserPermissionsMap | null, type: ModulePermissionType): boolean {
    return userPermissionsMap 
      ? userPermissionsMap[type]?.canRead || false
      : false;
  }
}
