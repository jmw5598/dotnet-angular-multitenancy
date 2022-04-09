import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzTableModule } from 'ng-zorro-antd/table';

import { UserAccountsRoutingModule } from './user-accounts-routing.module';
import { UserAccountsOverviewComponent } from './pages/user-accounts-overview/user-accounts-overview.component';
import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';

@NgModule({
  declarations: [
    UserAccountsOverviewComponent
  ],
  imports: [
    CommonModule,
    UserAccountsRoutingModule,
    XyzDatatableModule
  ]
})
export class UserAccountsModule { }
