import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';

import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';

import { UserAccountsRoutingModule } from './user-accounts-routing.module';
import { UserAccountsOverviewComponent } from './pages/user-accounts-overview/user-accounts-overview.component';
import { UserAccountsCreateComponent } from './pages/user-accounts-create/user-accounts-create.component';
import { UserAccountsUpdateComponent } from './pages/user-accounts-update/user-accounts-update.component';

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
    NzBreadCrumbModule,
    NzCardModule
  ]
})
export class UserAccountsModule { }
