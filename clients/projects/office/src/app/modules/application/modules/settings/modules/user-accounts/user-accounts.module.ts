import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzTableModule } from 'ng-zorro-antd/table';

import { UserAccountsRoutingModule } from './user-accounts-routing.module';
import { UserAccountsOverviewComponent } from './pages/user-accounts-overview/user-accounts-overview.component';
import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { UserAccountsCreateComponent } from './pages/user-accounts-create/user-accounts-create.component';
import { UserAccountsUpdateComponent } from './pages/user-accounts-update/user-accounts-update.component';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';

@NgModule({
  declarations: [
    UserAccountsOverviewComponent,
    UserAccountsCreateComponent,
    UserAccountsUpdateComponent
  ],
  imports: [
    CommonModule,
    UserAccountsRoutingModule,
    XyzDatatableModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule
  ]
})
export class UserAccountsModule { }
