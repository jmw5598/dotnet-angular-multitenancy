import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SecurityPermissionsComponent } from "./pages/security-permissions/security-permissions.component";

const routes: Routes = [
  {
    path: '',
    component: SecurityPermissionsComponent
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
