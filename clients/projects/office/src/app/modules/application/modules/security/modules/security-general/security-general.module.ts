import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecurityGeneralComponent } from './pages/security-general/security-general.component';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { SecurityGeneralRoutingModule } from './secuirty-general-routing.module';

@NgModule({
  declarations: [
    SecurityGeneralComponent
  ],
  imports: [
    CommonModule,
    SecurityGeneralRoutingModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule
  ]
})
export class SecurityGeneralModule { }
