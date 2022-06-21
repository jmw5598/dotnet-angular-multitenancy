import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticatedGuard } from '@xyz/office/modules/authentication/guards';
import { 
  TenantLoadedFromSubdomainGuard, 
  UserModulePermissionsLoadedGuard, 
  UserSettingsLoadedGuard } from './modules/core/guards';

const routes: Routes = [
  {
    path: 'app',
    canActivate: [
      AuthenticatedGuard,
      UserSettingsLoadedGuard,
      UserModulePermissionsLoadedGuard,
      TenantLoadedFromSubdomainGuard
    ],
    loadChildren: () => 
      import('./modules/application/application.module').then(m => m.ApplicationModule)
  },
  {
    path: 'error',
    loadChildren: () => 
      import('./modules/errors/errors.module').then(m => m.ErrorsModule)
  },
  {
    path: '',
    loadChildren: () => 
      import('./modules/authentication/authentication.module').then(m => m.AuthenticationModule)
  },
  {
    path: '**',
    redirectTo: 'app',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
