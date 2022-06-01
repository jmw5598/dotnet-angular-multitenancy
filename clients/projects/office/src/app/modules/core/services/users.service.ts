import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { BasicQuerySearchFilter } from '../../shared/modules/query-search-filter';
import { UserAccountDto } from '../dtos';
import { UserPermission } from '../entities';
import { Page, PageRequest, UserAccount, UserModulePermissions, UserSettings, ValidationResult } from '../models';
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

  public getUserSettings(): Observable<UserSettings> {
    return this.http.get<UserSettings>(
      `${this.environmentService.getBaseApiUrl()}/users/settings`
    );
  }

  public getUserPermissions(): Observable<UserModulePermissions> {
    return this.http.get<UserModulePermissions>(
      `${this.environmentService.getBaseApiUrl()}/users/permissions`
    );
  }
}
