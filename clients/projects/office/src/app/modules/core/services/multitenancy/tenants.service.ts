import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, PageRequest, Registration, ResponseMessage, TenantStatistics } from '../../models';
import { EnvironmentService } from '../environment.service';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

@Injectable({
  providedIn: 'root'
})
export class TenantsService {
  private readonly _endpointSlug: string = 'tenants';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public findTenantBySubdomain(subdomain: string): Observable<Tenant> {
    const queryParms: {[key: string]: string} = { subdomain };
    return this._http.get<Tenant>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/from-subdomain`,
      { params: queryParms }
    );
  }

  public getTenantStatistics(): Observable<TenantStatistics> {
    return this._http.get<TenantStatistics>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/statistics`
    );
  }

  public searchCompanies(filter: BasicQuerySearchFilter, pageRequest: PageRequest): Observable<Page<Tenant>> {
    const queryParams: {[key: string]: string } = { 
      query: filter?.query || '',
      size: pageRequest.size.toString(),
      index: pageRequest.index.toString(),
      column: pageRequest?.sort?.column?.toString() || '',
      direction: pageRequest?.sort?.direction?.toString() || ''
    };
    return this._http.get<Page<Tenant>>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/companies/search`,
      { params: queryParams }
    );
  }

  public register(registration: Registration): Observable<ResponseMessage> {
    return this._http.post<ResponseMessage>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/register`,
      registration
    );
  }
}
