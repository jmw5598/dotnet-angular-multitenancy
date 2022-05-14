import { Pipe, PipeTransform } from '@angular/core';

import { ModulePermissionNames, UserModulesAndPermissionsMap } from '@xyz/office/modules/core/models';

@Pipe({
  name: 'xyzHasModulePermission'
})
export class XyzHasModulePermissionPipe implements PipeTransform {
  public transform(
    userModulePermissionsMap: UserModulesAndPermissionsMap | null, 
    moduleName: ModulePermissionNames | null | undefined
  ): boolean {
    return userModulePermissionsMap && moduleName && userModulePermissionsMap?.modules?.hasOwnProperty(moduleName)
      ? userModulePermissionsMap?.modules[moduleName]?.hasAccess || false 
      : false;
  }
}
