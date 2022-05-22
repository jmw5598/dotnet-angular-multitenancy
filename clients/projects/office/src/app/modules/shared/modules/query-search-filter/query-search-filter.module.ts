import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';

import { BasicQuerySearchFilterComponent } from './components/basic-query-search-filter/basic-query-search-filter.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BasicQuerySearchFilterComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NzInputModule,
    NzButtonModule,
    NzIconModule
  ],
  exports: [
    BasicQuerySearchFilterComponent
  ]
})
export class XyzQuerySearchFilterModule { }
