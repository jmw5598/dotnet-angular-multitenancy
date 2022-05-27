import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AssignablePermissionsLoadedGuard } from '@xyz/office/modules/core/guards';

import { InitialTemplateModulePermissionNamesSearchLoadedGuard } from "./guards/initial-template-module-permission-names-search-loaded.guard";
import { SelectedTemplateModulePermissionNameLoadedGuard } from "./guards/selected-template-module-permission-name-loaded.guard";
import { SecurityPermissionsCreateComponent } from "./pages/security-permissions-create/security-permissions-create.component";
import { SecurityPermissionsUpdateComponent } from "./pages/security-permissions-update/security-permissions-update.component";
import { SecurityPermissionsComponent } from "./pages/security-permissions/security-permissions.component";

const routes: Routes = [
  {
    path: '',
    canActivate: [InitialTemplateModulePermissionNamesSearchLoadedGuard],
    component: SecurityPermissionsComponent
  },
  {
    path: 'create',
    canActivate: [AssignablePermissionsLoadedGuard],
    component: SecurityPermissionsCreateComponent
  },
  {
    path: ':templateModulePermissionNameId',
    canActivate: [SelectedTemplateModulePermissionNameLoadedGuard],
    children: [
      {
        path: 'edit',
        canActivate: [AssignablePermissionsLoadedGuard],
        component: SecurityPermissionsUpdateComponent
      }
    ]
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityPermissionsRoutingModule { }
