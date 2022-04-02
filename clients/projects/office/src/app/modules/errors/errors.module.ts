import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorNotFoundComponent } from './pages/error-not-found/error-not-found.component';
import { ErrorUnauthorizedComponent } from './pages/error-unauthorized/error-unauthorized.component';
import { ErrorPermissionDeniedComponent } from './pages/error-permission-denied/error-permission-denied.component';

import { ErrorsRoutingModule } from './errors-routing.module';

@NgModule({
  declarations: [
    ErrorNotFoundComponent,
    ErrorUnauthorizedComponent,
    ErrorPermissionDeniedComponent
  ],
  imports: [
    CommonModule,
    ErrorsRoutingModule
  ]
})
export class ErrorsModule { }
