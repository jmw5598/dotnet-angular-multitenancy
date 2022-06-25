import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { NzTableModule } from 'ng-zorro-antd/table';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';

import { DeepPropertyAccessPipe } from './pipes/deep-property-access.pipe';
import { XyzDatatableComponent } from './components/datatable/datatable.component';
import { XyzDatatableWidgetColumnEditorComponent } from './components/datatable-widget-column-editor/datatable-widget-column-editor.component';


@NgModule({
  declarations: [
    XyzDatatableComponent,
    XyzDatatableWidgetColumnEditorComponent,
    DeepPropertyAccessPipe
  ],
  imports: [
    CommonModule,
    DragDropModule, 
    FormsModule,
    NzTableModule,
    NzAvatarModule,
    NzIconModule,
    NzDropDownModule,
    NzButtonModule,
    NzCheckboxModule
  ],
  exports: [
    XyzDatatableComponent,
    XyzDatatableWidgetColumnEditorComponent
  ]
})
export class XyzDatatableModule { }
