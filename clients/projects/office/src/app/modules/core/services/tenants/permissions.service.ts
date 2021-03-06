import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { TemplateModulePermissionName, ModulePermission } from '@xyz/office/modules/core/entities/tenants';

import { Page, PageRequest } from '../../models';
import { EnvironmentService } from '../environment.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {
  private readonly _endpointSlug: string = 'security/permissions';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public createTemplateModulePermissionName(
    templateModulePermissionName: TemplateModulePermissionName): Observable<TemplateModulePermissionName> {

      return this._http.post<TemplateModulePermissionName>(
        `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates`,
        templateModulePermissionName
      );
  }

  public updateTemplateModulePermissionName(
    templateModulePermissionNameId: string, 
    templateModulePermissionName: TemplateModulePermissionName): Observable<TemplateModulePermissionName> {

      return this._http.put<TemplateModulePermissionName>(
        `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates/${templateModulePermissionNameId}`,
        templateModulePermissionName
      );
  }

  public searchTemplateModulePermissionNames(
    filter: BasicQuerySearchFilter, 
    pageRequest: PageRequest): Observable<Page<TemplateModulePermissionName>> {
      const queryParams: {[key: string]: string } = { 
        query: filter?.query || '',
        size: pageRequest.size.toString(),
        index: pageRequest.index.toString(),
        column: pageRequest?.sort?.column?.toString() || '',
        direction: pageRequest?.sort?.direction?.toString() || ''
      };
      return this._http.get<Page<TemplateModulePermissionName>>(
        `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates/search`,
        { params: queryParams }
      );
  }

  public getAssignableModulePermission(): Observable<ModulePermission[]> {
    return this._http.get<ModulePermission[]>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/available`
    );
  }

  public getTemplateModulePermissionNames(): Observable<TemplateModulePermissionName[]> {
    return this._http.get<TemplateModulePermissionName[]>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates`
    );
  }

  public getTemplateModulePermissionNameById(templateModulePermissionNameId: string): Observable<TemplateModulePermissionName> {
    return this._http.get<TemplateModulePermissionName>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates/${templateModulePermissionNameId}`
    );
  }

  public deleteTemplateModulePermissionNameById(templateModulePermissionNameId: string): Observable<TemplateModulePermissionName> {
    return this._http.delete<TemplateModulePermissionName>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/templates/${templateModulePermissionNameId}`
    );
  }
}
