import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzStepsModule } from 'ng-zorro-antd/steps';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';

import { AuthenticationRoutingModule } from './authentication-routing.module';

import { AuthenticationComponent } from './pages/authentication/authentication.component';
import { LoginComponent } from './pages/login/login.component';
import { ForgotPasswordComponent } from './pages/forgot-password/forgot-password.component';
import { LoggingInComponent } from './pages/logging-in/logging-in.component';
import { LoggingOutComponent } from './pages/logging-out/logging-out.component';
import { RegisterComponent } from './pages/register/register.component';
import { RegistrationUserFormComponent } from './components/registration-user-form/registration-user-form.component';
import { RegistrationProfileFormComponent } from './components/registration-profile-form/registration-profile-form.component';
import { RegistrationPlanFormComponent } from './components/registration-plan-form/registration-plan-form.component';
import { RegistrationCompanyFormComponent } from './components/registration-company-form/registration-company-form.component';
import { RegistrationCompleteComponent } from './components/registration-complete/registration-complete.component';
import { CompanySearchComponent } from './pages/company-search/company-search.component';

@NgModule({
  declarations: [
    AuthenticationComponent,
    LoginComponent,
    ForgotPasswordComponent,
    LoggingInComponent,
    LoggingOutComponent,
    RegisterComponent,
    RegistrationUserFormComponent,
    RegistrationProfileFormComponent,
    RegistrationPlanFormComponent,
    RegistrationCompanyFormComponent,
    RegistrationCompleteComponent,
    CompanySearchComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    ReactiveFormsModule,
    NzCheckboxModule,
    NzFormModule,
    NzInputModule,
    NzGridModule,
    NzButtonModule,
    NzCardModule,
    NzAlertModule,
    NzPageHeaderModule,
    NzSpinModule,
    NzStepsModule,
    NzIconModule,
    NzSelectModule,
    NzAutocompleteModule,
    NzAvatarModule
  ]
})
export class AuthenticationModule { }
