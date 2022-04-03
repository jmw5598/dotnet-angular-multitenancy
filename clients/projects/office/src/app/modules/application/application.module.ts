import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';

import { ApplicationRoutingModule } from './application-routing.module';

import { ApplicationComponent } from './pages/application/application.component';
import { NavigationMenuComponent } from './components/navigation-menu/navigation-menu.component';
import { XyzPermissionsModule } from '../shared/modules/permissions';

@NgModule({
  declarations: [
    ApplicationComponent,
    NavigationMenuComponent
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    XyzPermissionsModule,
    NzLayoutModule,
    NzBreadCrumbModule,
    NzMenuModule,
    NzIconModule,
    NzDropDownModule,
    NzAvatarModule
  ]
})
export class ApplicationModule { }
