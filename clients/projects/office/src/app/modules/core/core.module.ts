import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtTokenInterceptor } from './interceptors';
import { CACHE_SERVICE, SessionCacheService } from './services';

const jwtTokenInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtTokenInterceptor,
  multi: true
}

const windowProvider = {
  provide: Window,
  useValue: window
}

const cacheProvider = {
  provide: CACHE_SERVICE,
  useExisting: SessionCacheService
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    jwtTokenInterceptorProvider,
    windowProvider,
    cacheProvider
  ]
})
export class CoreModule { }
