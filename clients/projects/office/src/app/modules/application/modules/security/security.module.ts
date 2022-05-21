import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SecurityRoutingModule } from './security-routing.module';

import * as fromSecurity from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    StoreModule.forFeature(fromSecurity.administrationFeatureKey, fromSecurity.reducers),
    EffectsModule.forFeature([...fromSecurity.securityEffects])
  ]
})
export class SecurityModule { }
