import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
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
    component: UserAccountsCreateComponent
  },
  {
    path: ':userId',
    children: [
      {
        path: 'edit',
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
