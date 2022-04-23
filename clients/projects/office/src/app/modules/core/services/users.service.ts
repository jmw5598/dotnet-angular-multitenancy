import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { UserDto } from '../dtos';
import { Permission } from '../entities';

import { Page, PageRequest, UserAccount, ValidationResult } from '../models';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(
    protected http: HttpClient,
    protected environmentService: EnvironmentService
  ) { }

  public verifyEmail(email: string): Observable<ValidationResult> {
    return this.http.get<ValidationResult>(
      `${this.environmentService.getBaseApiUrl()}/users/verify/email`,
      { params: { email: email } }
    )
  }

  public verifyUserName(userName: string): Observable<ValidationResult> {
    return this.http.get<ValidationResult>(
      `${this.environmentService.getBaseApiUrl()}/users/verify/username`,
      { params: { userName: userName } }
    );
  }

  public searchUsers(pageRequest: PageRequest): Observable<Page<UserDto>> {
    return this.http.get<Page<UserDto>>(
      `${this.environmentService.getBaseApiUrl()}/users/search`
    );
  }

  public getAssignablePermission(): Observable<Permission[]> {
    return this.http.get<Permission[]>(
      `${this.environmentService.getBaseApiUrl()}/users/permissions`
    );
  }

  public createUserAccount(userAccount: UserAccount): Observable<UserDto> {
    return this.http.post<UserDto>(
      `${this.environmentService.getBaseApiUrl()}/users`,
      userAccount
    );
  }
}
