import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HasModulePermissionGuard } from "@xyz/office/modules/core/guards";
import { ModulePermissionType } from "@xyz/office/modules/core/models";
import { SettingsComponent } from "./pages/settings/settings.component";

const routes: Routes = [
  {
    path: '',
    component: SettingsComponent
  },
  {
    path: 'user-accounts',
    // canActivate: [HasModulePermissionGuard],
    data: {
      modulePermissionType: ModulePermissionType.UserAccounts
    },
    loadChildren: () => import('./modules/user-accounts/user-accounts.module').then(m => m.UserAccountsModule)
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
export class SettingsRoutingModule { }
