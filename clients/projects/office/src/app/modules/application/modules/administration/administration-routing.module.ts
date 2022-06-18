import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HasPermissionGuard } from '@xyz/office/modules/core/guards';
import { PermissionNames } from '@xyz/office/modules/core/models';

const routes: Routes = [
  {
    path: 'settings',
    loadChildren: () => import('./modules/settings/settings.module').then(m => m.SettingsModule)
  },
  {
    path: 'user-accounts',
    canActivate: [HasPermissionGuard],
    data: {
      requiredPermissionName: PermissionNames.USER_ACCOUNTS
    },
    loadChildren: () => import('./modules/user-accounts/user-accounts.module').then(m => m.UserAccountsModule)
  },
  {
    path: 'account-details',
    canActivate: [HasPermissionGuard],
    data: {
      requiredPermissionName: PermissionNames.ACCOUNT_DETAILS
    },
    loadChildren: () => import('./modules/account-details/account-details.module').then(m => m.AccountDetailsModule)
  },
  {
    path: '**',
    redirectTo: 'settings',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
