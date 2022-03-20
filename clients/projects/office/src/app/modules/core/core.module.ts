import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtTokenInterceptor } from './interceptors';

const jwtTokenInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: JwtTokenInterceptor,
  multi: true
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    jwtTokenInterceptorProvider
  ]
})
export class CoreModule { }
