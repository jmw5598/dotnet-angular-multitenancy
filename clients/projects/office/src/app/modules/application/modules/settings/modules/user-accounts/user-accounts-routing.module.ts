import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { UserAccountsOverviewComponent } from "./pages/user-accounts-overview/user-accounts-overview.component";

const routes: Routes = [
  {
    path: '',
    component: UserAccountsOverviewComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAccountsRoutingModule { }
