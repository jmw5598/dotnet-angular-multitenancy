import { APP_INITIALIZER, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtTokenInterceptor } from './interceptors';
import { CACHE_SERVICE, SessionCacheService } from './services';
import { authenticatedUserInitializer } from './initializers/authenticated-user.initializer';
import { Store } from '@ngrx/store';
import { AuthenticationService } from '../authentication/services/authentication.service';

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

const authenticationUserAppInitializer = { 
  provide: APP_INITIALIZER, 
  useFactory: authenticatedUserInitializer, 
  multi: true,
  deps: [Store, AuthenticationService]
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    jwtTokenInterceptorProvider,
    windowProvider,
    cacheProvider,
    authenticationUserAppInitializer
  ]
})
export class CoreModule { }
