import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { defaultDateRangeQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { BillingInvoice } from '@xyz/office/modules/core/entities';
import { Page, PageRequest, Sort } from '@xyz/office/modules/core/models';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { Observable, tap } from 'rxjs';
import { defaultUserAccountsSort } from '../../../user-accounts/constants/sort.defaults';

import * as fromBilling from '../../store/billing';
import { defaultBillingInvoicesTableDefinition } from './billing-invoices-table-definition.defaults';

@Component({
  selector: 'xyz-billing',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BillingComponent implements OnInit {
  private _defaultPageRequest: PageRequest = defaultPageRequest;
  public defaultSort: Sort = defaultUserAccountsSort;

  public billingInvoicesPage$: Observable<Page<BillingInvoice> | null>;
  public billingInvoicesSearchFilter$: Observable<DateRangeQuerySearchFilter | null>;
  public billingInvoicesSearchFilter!: DateRangeQuerySearchFilter | null;

  public billingInvoicesTableDefinition: TableDefinition = defaultBillingInvoicesTableDefinition;

  constructor(
    private _store: Store<fromBilling.BillingState>
  ) {
    this.billingInvoicesPage$ = this._store.select(fromBilling.selectBillingInvoicesPage);
    this.billingInvoicesSearchFilter$ = this._store.select(fromBilling.selectBillingInvoicesSearchFilter)
      .pipe(tap(filter => this.billingInvoicesSearchFilter = filter));
  }

  ngOnInit(): void {
  }

  public onSearchFilterChanges(filter: DateRangeQuerySearchFilter): void {
    this._store.dispatch(fromBilling.setBillingInvoicesSearchFilter({ filter: filter }));
    this._searchBillingInvoices(filter, this._defaultPageRequest);
  }

  public onBillingInvoicesPageChange(pageRequest: PageRequest): void {
    this._searchBillingInvoices(this.billingInvoicesSearchFilter, pageRequest);
  }

  private _searchBillingInvoices(filter: DateRangeQuerySearchFilter | null, pageRequest: PageRequest): void {
    this._store.dispatch(fromBilling.searchBillingInvoicesRequest({
      filter: filter || defaultDateRangeQuerySearchFilter,
      pageRequest: pageRequest
    }));
  }
}
