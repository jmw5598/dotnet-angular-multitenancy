import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AssignablePermissionsLoadedGuard } from "./guards/assignable-permissions-loaded.guard";
import { UserAccountsCreateComponent } from "./pages/user-accounts-create/user-accounts-create.component";

import { UserAccountsOverviewComponent } from "./pages/user-accounts-overview/user-accounts-overview.component";
import { UserAccountsUpdateComponent } from "./pages/user-accounts-update/user-accounts-update.component";

const routes: Routes = [
  {
    path: '',
    component: UserAccountsOverviewComponent
  },
  {
    path: 'create',
    canActivate: [AssignablePermissionsLoadedGuard],
    component: UserAccountsCreateComponent
  },
  {
    path: ':userId',
    children: [
      {
        path: 'edit',
        canActivate: [AssignablePermissionsLoadedGuard],
        component: UserAccountsUpdateComponent
      }
    ]
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAccountsRoutingModule { }
