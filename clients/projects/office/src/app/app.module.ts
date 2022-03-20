import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';

import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';

import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ROOT_REDUCERS, metaReducers, rootEffects } from './store';

import { environment } from '@xyz/office/env/environment';
import { CoreModule } from './modules/core/core.module';

registerLocaleData(en);

const storeModuleRuntimeChecks = {
  // strictStateImmutability and strictActionImmutability are enabled by default
  strictStateSerializability: true,
  strictActionSerializability: true,
  strictActionWithinNgZone: true,
  strictActionTypeUniqueness: true,
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    StoreModule.forRoot(ROOT_REDUCERS, { metaReducers, runtimeChecks: storeModuleRuntimeChecks }),
    EffectsModule.forRoot([...rootEffects]),
    StoreDevtoolsModule.instrument({ name: 'Xyz Project Store', logOnly: environment.production, }),
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    { provide: Window, useValue: window },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
