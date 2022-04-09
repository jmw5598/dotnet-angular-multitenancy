import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { XyzDatatableComponent } from './components/datatable/datatable.component';

import { NzTableModule } from 'ng-zorro-antd/table';

@NgModule({
  declarations: [
    XyzDatatableComponent
  ],
  imports: [
    CommonModule,
    NzTableModule
  ],
  exports: [
    XyzDatatableComponent
  ]
})
export class XyzDatatableModule { }
