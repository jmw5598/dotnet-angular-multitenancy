import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './pages/settings/settings.component';

import * as fromSettings from './store';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    StoreModule.forFeature(fromSettings.settingsFeatureKey, fromSettings.reducers),
    EffectsModule.forFeature([...fromSettings.settingsEffects])
  ]
})
export class SettingsModule { }
