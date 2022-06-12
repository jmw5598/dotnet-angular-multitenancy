import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzStatisticModule } from 'ng-zorro-antd/statistic';
import { NzDividerModule } from 'ng-zorro-antd/divider';

import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';
import { XyzQuerySearchFilterModule } from '@xyz/office/modules/shared/modules/query-search-filter';

import { AccountDetailsRoutingModule } from './account-details-routing.module';
import { AccountDetailsComponent } from './pages/account-details/account-details.component';
import { AccountInformationComponent } from './pages/account-information/account-information.component';
import { BillingComponent } from './pages/billing/billing.component';

@NgModule({
  declarations: [
    AccountDetailsComponent,
    AccountInformationComponent,
    BillingComponent
  ],
  imports: [
    CommonModule,
    AccountDetailsRoutingModule,
    XyzDatatableModule,
    XyzQuerySearchFilterModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule,
    NzTabsModule,
    NzStatisticModule,
    NzDividerModule
  ]
})
export class AccountDetailsModule { }
