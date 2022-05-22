import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { BasicQuerySearchFilter } from '../../shared/modules/query-search-filter';
import { UserAccountDto } from '../dtos';
import { ModulePermission, UserPermission } from '../entities';

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

  public searchUsers(filter: BasicQuerySearchFilter, pageRequest: PageRequest): Observable<Page<UserAccountDto>> {
    const queryParams: {[key: string]: string } = { query: filter?.query || '' };
    return this.http.get<Page<UserAccountDto>>(
      `${this.environmentService.getBaseApiUrl()}/users/search`,
      { params: queryParams }
    );
  }

  public getAssignableModulePermission(): Observable<ModulePermission[]> {
    return this.http.get<ModulePermission[]>(
      `${this.environmentService.getBaseApiUrl()}/users/module-permissions`
    );
  }

  public createUserAccount(userAccount: UserAccount): Observable<UserAccountDto> {
    return this.http.post<UserAccountDto>(
      `${this.environmentService.getBaseApiUrl()}/users`,
      userAccount
    );
  }

  public updateUserAccount(userId: string, userAccount: UserAccount): Observable<UserAccountDto> {
    return this.http.put<UserAccountDto>(
      `${this.environmentService.getBaseApiUrl()}/users/${userId}`,
      userAccount
    );
  }

  public getUserByUserId(userId: string): Observable<UserAccountDto> {
    return this.http.get<UserAccountDto>(
      `${this.environmentService.getBaseApiUrl()}/users/${userId}`
    );
  }

  public getUserPermissionsByUserId(userId: string): Observable<UserPermission[]> {
    return this.http.get<UserPermission[]>(
      `${this.environmentService.getBaseApiUrl()}/users/${userId}/permissions`
    );
  }
}
