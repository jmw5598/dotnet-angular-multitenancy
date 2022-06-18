import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HasPermissionGuard } from '@xyz/office/modules/core/guards';
import { PermissionNames } from '@xyz/office/modules/core/models';

const routes: Routes = [
  {
    path: 'general',
    canActivate: [HasPermissionGuard],
    data: {
      requiredPermissionName: PermissionNames.SECURITY_GENERAL
    },
    loadChildren: () => import('./modules/security-general/security-general.module').then(m => m.SecurityGeneralModule)
  },
  {
    path: 'permissions',
    canActivate: [HasPermissionGuard],
    data: {
      requiredPermissionName: PermissionNames.SECURITY_PERMISSIONS
    },
    loadChildren: () => import('./modules/security-permissions/security-permissions.module').then(m => m.SecurityPermissionsModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
