import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ValidatorResult } from '../models';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(
    protected http: HttpClient,
    protected environmentService: EnvironmentService
  ) { }

  public verifyEmail(email: string): Observable<ValidatorResult> {
    return of({ 
      isValid: false 
    } as ValidatorResult);
  }

  public verifyUserName(userName: string): Observable<ValidatorResult> {
    return of({ 
      isValid: false 
    } as ValidatorResult);
  }
}
