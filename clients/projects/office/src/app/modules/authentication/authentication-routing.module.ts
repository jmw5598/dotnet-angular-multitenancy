import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AvailablePlansLoadedGuard } from "../core/guards/available-plans-loaded.guard";
import { AuthenticationComponent } from "./pages/authentication/authentication.component";
import { ForgotPasswordComponent } from "./pages/forgot-password/forgot-password.component";
import { LoggingInComponent } from "./pages/logging-in/logging-in.component";
import { LoggingOutComponent } from "./pages/logging-out/logging-out.component";
import { LoginComponent } from "./pages/login/login.component";
import { RegisterComponent } from "./pages/register/register.component";

const routes: Routes = [
  {
    path: '',
    component: AuthenticationComponent,
    children: [
      {
        path: 'login',
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
        component: ForgotPasswordComponent
      },
      {
        path: 'register',
        canActivate: [AvailablePlansLoadedGuard],
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
