import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { XyzCanCreatePipe } from './pipes/can-create.pipe';
import { XyzCanReadPipe } from './pipes/can-read.pipe';
import { XyzCanUpdatePipe } from './pipes/can-update.pipe';
import { XyzCanDeletePipe } from './pipes/can-delete.pipe';

@NgModule({
  declarations: [
    XyzCanCreatePipe,
    XyzCanReadPipe,
    XyzCanUpdatePipe,
    XyzCanDeletePipe,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    XyzCanCreatePipe,
    XyzCanReadPipe,
    XyzCanUpdatePipe,
    XyzCanDeletePipe,
  ]
})
export class XyzPermissionsModule { }
