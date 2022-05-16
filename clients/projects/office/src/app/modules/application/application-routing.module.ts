import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HasModulePermissionGuard } from '../core/guards';
import { ModulePermissionNames } from '../core/models';

import { ApplicationComponent } from './pages/application/application.component';

const routes: Routes = [
  {
    path: '',
    component: ApplicationComponent,
    children: [
      {
        path: 'admin',
        canActivate: [HasModulePermissionGuard],
        data: {
          requiredModulePermissionName: ModulePermissionNames.ADMINISTRATION_MODULE
        },
        loadChildren: () => import('./modules/administration/administration.module').then(m => m.AdministrationModule)
      },
      {
        path: 'dashboard',
        canActivate: [HasModulePermissionGuard],
        data: {
          requiredModulePermissionName: ModulePermissionNames.DASHBOARD_MODULE
        },
        loadChildren: () => import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'security',
        canActivate: [HasModulePermissionGuard],
        data: {
          requiredModulePermissionName: ModulePermissionNames.SECURITY_MODULE
        },
        loadChildren: () => import('./modules/security/security.module').then(m => m.SecurityModule)
      },
      {
        path: 'service',
        canActivate: [HasModulePermissionGuard],
        data: {
          requiredModulePermissionName: ModulePermissionNames.SERVICE_MODULE
        },
        loadChildren: () => import('./modules/service/service.module').then(m => m.ServiceModule)
      },
      {
        path: 'inventory',
        canActivate: [HasModulePermissionGuard],
        data: {
          requiredModulePermissionName: ModulePermissionNames.INVENTORY_MODULE
        },
        loadChildren: () => import('./modules/inventory/inventory.module').then(m => m.InventoryModule)
      },
      {
        path: '**',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationRoutingModule { }
