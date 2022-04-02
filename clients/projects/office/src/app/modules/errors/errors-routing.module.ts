import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticatedGuard } from '@xyz/office/modules/authentication/guards';
import { ErrorNotFoundComponent } from './pages/error-not-found/error-not-found.component';
import { ErrorPermissionDeniedComponent } from './pages/error-permission-denied/error-permission-denied.component';
import { ErrorUnauthorizedComponent } from './pages/error-unauthorized/error-unauthorized.component';

const routes: Routes = [
  {
    path: '401',
    component: ErrorUnauthorizedComponent
  },
  {
    path: '403',
    component: ErrorPermissionDeniedComponent 
  },
  {
    path: '404',
    component: ErrorNotFoundComponent 
  },
  {
    path: '**',
    redirectTo: '404',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ErrorsRoutingModule { }