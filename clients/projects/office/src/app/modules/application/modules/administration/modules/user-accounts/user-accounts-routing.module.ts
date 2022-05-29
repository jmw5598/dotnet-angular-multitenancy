import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AssignablePermissionsLoadedGuard } from "@xyz/office/modules/core/guards";

import { InitialUserAccountsSearchLoadedGuard } from "./guards/initial-user-accounts-search-loaded.guard";
import { SelectedUsersAccountLoadedGuard } from "./guards/selected-users-account-loaded.guard";
import { TemplateModulePermissionNamesLoadedGuard } from "./guards/template-module-permission-names-loaded.guard";
import { UserAccountsCreateComponent } from "./pages/user-accounts-create/user-accounts-create.component";

import { UserAccountsOverviewComponent } from "./pages/user-accounts-overview/user-accounts-overview.component";
import { UserAccountsUpdateComponent } from "./pages/user-accounts-update/user-accounts-update.component";

const routes: Routes = [
  {
    path: '',
    canActivate: [InitialUserAccountsSearchLoadedGuard],
    component: UserAccountsOverviewComponent
  },
  {
    path: 'create',
    canActivate: [
      AssignablePermissionsLoadedGuard,
      TemplateModulePermissionNamesLoadedGuard
    ],
    component: UserAccountsCreateComponent
  },
  {
    path: ':userId',
    children: [
      {
        path: 'edit',
        canActivate: [
          AssignablePermissionsLoadedGuard,
          TemplateModulePermissionNamesLoadedGuard,
          SelectedUsersAccountLoadedGuard
        ],
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
