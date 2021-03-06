import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecurityPermissionsComponent } from './pages/security-permissions/security-permissions.component';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';

import { SecurityPermissionsRoutingModule } from './security-permissions-routing.module';
import { SecurityPermissionsCreateComponent } from './pages/security-permissions-create/security-permissions-create.component';
import { SecurityPermissionsUpdateComponent } from './pages/security-permissions-update/security-permissions-update.component';

import { XyzDatatableModule } from '@xyz/office/modules/shared/modules/datatable';
import { XyzQuerySearchFilterModule } from '@xyz/office/modules/shared/modules/query-search-filter';
import { ReactiveFormsModule } from '@angular/forms';
import { TemplateModulePermissionNameFormComponent } from './components/template-module-permission-name-form/template-module-permission-name-form.component';

@NgModule({
  declarations: [
    SecurityPermissionsComponent,
    SecurityPermissionsCreateComponent,
    SecurityPermissionsUpdateComponent,
    TemplateModulePermissionNameFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SecurityPermissionsRoutingModule,
    XyzDatatableModule,
    XyzQuerySearchFilterModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule,
    NzDividerModule,
    NzFormModule,
    NzInputModule,
    NzCheckboxModule,
    NzListModule,
    NzCollapseModule,
    NzSwitchModule,
    NzPopconfirmModule
  ]
})
export class SecurityPermissionsModule { }
