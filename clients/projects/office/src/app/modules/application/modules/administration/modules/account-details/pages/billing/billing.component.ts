import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { defaultDateRangeQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { BillingInvoice, Tenant } from '@xyz/office/modules/core/entities/multitenancy';
import { Page, PageRequest, Sort } from '@xyz/office/modules/core/models';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { DateRangeQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { Observable, tap } from 'rxjs';
import { defaultUserAccountsSort } from '../../../user-accounts/constants/sort.defaults';

import * as fromTenant from '@xyz/office/store/tenant';
import * as fromBilling from '../../store/billing';

@Component({
  selector: 'xyz-billing',
  templateUrl: './billing.component.html',
  styleUrls: ['./billing.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BillingComponent {
  private _defaultPageRequest: PageRequest = defaultPageRequest;
  public defaultSort: Sort = defaultUserAccountsSort;

  public billingInvoicesPage$: Observable<Page<BillingInvoice> | null>;
  public billingInvoicesSearchFilter$: Observable<DateRangeQuerySearchFilter | null>;
  public billingInvoicesSearchFilter!: DateRangeQuerySearchFilter | null;

  public billingInvoicesTableDefinition$: Observable<TableDefinition | null>;

  public tenant$: Observable<Tenant | null>;

  constructor(
    private _store: Store<fromBilling.BillingState>
  ) {
    this.billingInvoicesPage$ = this._store.select(fromBilling.selectBillingInvoicesPage);
    this.billingInvoicesSearchFilter$ = this._store.select(fromBilling.selectBillingInvoicesSearchFilter)
      .pipe(tap(filter => this.billingInvoicesSearchFilter = filter));
    this.billingInvoicesTableDefinition$ = this._store.select(fromBilling.selectBillingInvoicesTableDefinition);
    this.tenant$ = this._store.select(fromTenant.selectTenant);
  }

  public onSearchFilterChanges(filter: DateRangeQuerySearchFilter): void {
    this._store.dispatch(fromBilling.setBillingInvoicesSearchFilter({ filter: filter }));
    this._searchBillingInvoices(filter, this._defaultPageRequest);
  }

  public onBillingInvoicesPageChange(pageRequest: PageRequest): void {
    this._searchBillingInvoices(this.billingInvoicesSearchFilter, pageRequest);
  }

  public onApplyColumnChanges(tableDefinition: TableDefinition | null): void {
    this._store.dispatch(
      fromBilling.setBillingInvoicesTableDefinition({
        tableDefinition: tableDefinition
      })
    );
  }

  public onResetColumnChanges(shouldReset: boolean): void {
    if (shouldReset) {
      this._store.dispatch(fromBilling.resetBillingInvoicesTableDefinition());
    }
  }

  private _searchBillingInvoices(filter: DateRangeQuerySearchFilter | null, pageRequest: PageRequest): void {
    this._store.dispatch(fromBilling.searchBillingInvoicesRequest({
      filter: filter || defaultDateRangeQuerySearchFilter,
      pageRequest: pageRequest
    }));
  }
}
