import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { InitialTemplateModulePermissionNamesSearchLoadedGuard } from "./guards/initial-template-module-permission-names-search-loaded.guard";
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
    canActivate: [],
    component: SecurityPermissionsCreateComponent
  },
  {
    path: ':permissionsTemplateId',
    children: [
      {
        path: 'edit',
        canActivate: [],
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
