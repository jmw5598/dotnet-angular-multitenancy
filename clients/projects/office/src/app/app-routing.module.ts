import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticatedGuard } from '@xyz/office/modules/authentication/guards';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => 
      import('./modules/authentication/authentication.module').then(m => m.AuthenticationModule)
  },
  {
    path: '',
    canActivate: [AuthenticatedGuard],
    loadChildren: () => 
      import('./modules/application/application.module').then(m => m.ApplicationModule)
  },
  {
    path: '**',
    redirectTo: 'auth',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
