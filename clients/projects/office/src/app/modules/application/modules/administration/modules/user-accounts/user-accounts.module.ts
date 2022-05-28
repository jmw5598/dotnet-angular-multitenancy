import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzSelectModule } from 'ng-zorro-antd/select';

import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';
import { XyzQuerySearchFilterModule } from '@xyz/office/modules/shared/modules/query-search-filter';

import { UserAccountsRoutingModule } from './user-accounts-routing.module';
import { UserAccountsOverviewComponent } from './pages/user-accounts-overview/user-accounts-overview.component';
import { UserAccountsCreateComponent } from './pages/user-accounts-create/user-accounts-create.component';
import { UserAccountsUpdateComponent } from './pages/user-accounts-update/user-accounts-update.component';
import { UserAccountUpdateFormComponent } from './components/user-account-update-form/user-account-update-form.component';
import { UserAccountCreateFormComponent } from './components/user-account-create-form/user-account-create-form.component';

@NgModule({
  declarations: [
    UserAccountsOverviewComponent,
    UserAccountsCreateComponent,
    UserAccountsUpdateComponent,
    UserAccountUpdateFormComponent,
    UserAccountCreateFormComponent,
  ],
  imports: [
    CommonModule,
    UserAccountsRoutingModule,
    ReactiveFormsModule,
    XyzDatatableModule,
    XyzQuerySearchFilterModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzFormModule,
    NzGridModule,
    NzInputModule,
    NzCheckboxModule,
    NzDividerModule,
    NzListModule,
    NzCollapseModule,
    NzSwitchModule,
    NzUploadModule,
    NzPopoverModule,
    NzSelectModule
  ]
})
export class UserAccountsModule { }
