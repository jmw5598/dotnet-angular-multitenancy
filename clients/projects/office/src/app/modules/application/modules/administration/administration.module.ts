import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdministrationRoutingModule } from './administration-routing.module';

import * as fromAdminstration from './store';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    StoreModule.forFeature(fromAdminstration.administrationFeatureKey, fromAdminstration.reducers),
    EffectsModule.forFeature([...fromAdminstration.adminsitrationEffects])
  ]
})
export class AdministrationModule { }
