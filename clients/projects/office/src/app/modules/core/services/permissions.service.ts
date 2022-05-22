import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TemplateModulePermissionName } from '../entities';

import { BasicQuerySearchFilter, Page, PageRequest } from '../models';
import { EnvironmentService } from './environment.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {
  private readonly _endpointSlug: string = 'security/permissions';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public searchTemplateModulePermissionNames(filter: BasicQuerySearchFilter, pageRequest: PageRequest): Observable<Page<TemplateModulePermissionName>> {
    const queryParams: {[key: string]: string } = { query: filter?.query || '' };
    return this._http.get<Page<TemplateModulePermissionName>>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates/search`,
      { params: queryParams }
    );
  }
}
