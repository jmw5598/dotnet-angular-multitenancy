import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HasPermissionGuard } from "@xyz/office/modules/core/guards";

import { PermissionNames } from "@xyz/office/modules/core/models";
import { TenantStatisticsLoadedGuard } from "./guards/tenant-statistics-loaded.guard";
import { AccountDetailsComponent } from "./pages/account-details/account-details.component";
import { AccountInformationComponent } from "./pages/account-information/account-information.component";
import { BillingComponent } from "./pages/billing/billing.component";

const routes: Routes = [
  {
    path: '',
    canActivate: [TenantStatisticsLoadedGuard],
    component: AccountDetailsComponent,
    children: [
      {
        path: 'info',
        component: AccountInformationComponent
      },
      {
        path: 'billing',
        component: BillingComponent
      },
      {
        path: '**',
        redirectTo: 'info',
        pathMatch: 'full'
      }
    ],
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
export class AccountDetailsRoutingModule { }
