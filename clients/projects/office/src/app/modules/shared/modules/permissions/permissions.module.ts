import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { XyzCanCreatePipe } from './pipes/can-create.pipe';
import { XyzCanReadPipe } from './pipes/can-read.pipe';
import { XyzCanUpdatePipe } from './pipes/can-update.pipe';
import { XyzCanDeletePipe } from './pipes/can-delete.pipe';
import { XyzHasModulePermissionPipe } from './pipes/has-module-permission.pipe';

@NgModule({
  declarations: [
    XyzCanCreatePipe,
    XyzCanReadPipe,
    XyzCanUpdatePipe,
    XyzCanDeletePipe,
    XyzHasModulePermissionPipe,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    XyzCanCreatePipe,
    XyzCanReadPipe,
    XyzCanUpdatePipe,
    XyzCanDeletePipe,
    XyzHasModulePermissionPipe
  ]
})
export class XyzPermissionsModule { }
