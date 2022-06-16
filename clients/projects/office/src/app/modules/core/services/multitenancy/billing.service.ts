import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import { BillingInvoice } from '../../entities';
import { Page, PageRequest } from '../../models';
import { EnvironmentService } from '../environment.service';

@Injectable({
  providedIn: 'root'
})
export class BillingService {
  private readonly _endpointSlug: string = 'admin/billing';

  constructor(
    private _environmentService: EnvironmentService,
    private _http: HttpClient
  ) { }

  public searchBillingInvoices(filter: DateRangeQuerySearchFilter, pageRequest: PageRequest): Observable<Page<BillingInvoice>> {
    const queryParms: {[key: string]: string} = {
      query: filter?.query || '',
      startDate: filter?.startDate || '',
      endDate: filter?.endDate || '',
      size: pageRequest.size.toString(),
      index: pageRequest.index.toString(),
      column: pageRequest?.sort?.column?.toString() || '',
      direction: pageRequest?.sort?.direction?.toString() || ''
    };
    return this._http.get<Page<BillingInvoice>>(
      `${this._environmentService.getBaseApiUrl()}/${this._endpointSlug}/invoices/search`,
      { params: queryParms }
    );
  }
}
