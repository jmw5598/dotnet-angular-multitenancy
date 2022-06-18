import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ValidationResult } from '../../models';

import { EnvironmentService } from '../environment.service';

@Injectable({
  providedIn: 'root'
})
export class CompaniesService {
  private readonly _endpointSlug: string = 'companies';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public doesCompanyExist(companyName: string): Observable<ValidationResult> {
    const queryParms: {[key: string]: string} = { companyName };
    return this._http.get<ValidationResult>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/exists`,
      { params: queryParms }
    );
  }
}
