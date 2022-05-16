import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecurityPermissionsComponent } from './pages/security-permissions/security-permissions.component';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { SecurityPermissionsRoutingModule } from './security-permissions-routing.module';

@NgModule({
  declarations: [
    SecurityPermissionsComponent
  ],
  imports: [
    CommonModule,
    SecurityPermissionsRoutingModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule
  ]
})
export class SecurityPermissionsModule { }
