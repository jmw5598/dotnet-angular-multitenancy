import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TenantLoadedFromSubdomainGuard } from '../core/guards';

import { AvailablePlansLoadedGuard } from '../core/guards/available-plans-loaded.guard';
import { IsLoadedFromSubdomainGuard } from './guards/is-loaded-from-subdomain.guard';
import { IsNotLoadedFromSubdomainGuard } from './guards/is-not-loaded-from-subdomain.guard';

import { AuthenticationComponent } from './pages/authentication/authentication.component';
import { CompanySearchComponent } from './pages/company-search/company-search.component';
import { ForgotPasswordComponent } from './pages/forgot-password/forgot-password.component';
import { LoggingInComponent } from './pages/logging-in/logging-in.component';
import { LoggingOutComponent } from './pages/logging-out/logging-out.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  {
    path: '',
    component: AuthenticationComponent,
    children: [
      {
        path: 'company-search',
        canActivate: [IsLoadedFromSubdomainGuard],
        component: CompanySearchComponent
      },
      {
        path: 'login',
        canActivate: [
          IsNotLoadedFromSubdomainGuard,
          TenantLoadedFromSubdomainGuard
        ],
        component: LoginComponent
      },
      {
        path: 'logging-in',
        component: LoggingInComponent
      },
      {
        path: 'logging-out',
        component: LoggingOutComponent
      },
      {
        path: 'forgot-password',
        canActivate: [IsNotLoadedFromSubdomainGuard],
        component: ForgotPasswordComponent
      },
      {
        path: 'register',
        canActivate: [
          IsLoadedFromSubdomainGuard,
          AvailablePlansLoadedGuard
        ],
        component: RegisterComponent
      },
      {
        path: '**',
        redirectTo: 'login',
        pathMatch: 'full'
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
