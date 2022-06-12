import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzFormModule } from 'ng-zorro-antd/form';

import { BasicQuerySearchFilterComponent } from './components/basic-query-search-filter/basic-query-search-filter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DateRangeQuerySearchFilterComponent } from './components/date-range-query-search-filter/date-range-query-search-filter.component';

@NgModule({
  declarations: [
    BasicQuerySearchFilterComponent,
    DateRangeQuerySearchFilterComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NzInputModule,
    NzButtonModule,
    NzIconModule,
    NzDatePickerModule,
    NzGridModule,
    NzFormModule,
  ],
  exports: [
    BasicQuerySearchFilterComponent,
    DateRangeQuerySearchFilterComponent
  ]
})
export class XyzQuerySearchFilterModule { }
