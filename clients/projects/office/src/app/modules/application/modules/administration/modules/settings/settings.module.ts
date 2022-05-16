import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './pages/settings/settings.component';

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzCardModule,
    NzGridModule
  ]
})
export class SettingsModule { }
