import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModulePermissions, UserSettings } from '../models';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public getUserSettings(): Observable<UserSettings> {
    return this._http.get<UserSettings>(
      `${this._environmentService.getBaseApiUrl()}/user/settings`
    );
  }

  public getUserPermissions(): Observable<UserModulePermissions> {
    return this._http.get<UserModulePermissions>(
      `${this._environmentService.getBaseApiUrl()}/user/permissions`
    );
  }
}
