import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserAccountsRoutingModule } from './user-accounts-routing.module';
import { UserAccountsOverviewComponent } from './pages/user-accounts-overview/user-accounts-overview.component';

@NgModule({
  declarations: [
    UserAccountsOverviewComponent
  ],
  imports: [
    CommonModule,
    UserAccountsRoutingModule
  ]
})
export class UserAccountsModule { }
