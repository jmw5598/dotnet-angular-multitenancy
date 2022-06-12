import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Page, PageRequest, Sort } from '@xyz/office//modules/core/models';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromUserAccounts from '../../store';
import { defaultUserAccountsSort } from '../../constants/sort.defaults';
import { defaultUserAccountsTableDefinition } from './user-accounts-table-definition.defaults';

@Component({
  selector: 'xyz-user-accounts-overview',
  templateUrl: './user-accounts-overview.component.html',
  styleUrls: ['./user-accounts-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsOverviewComponent {
  public userAccountsPage$!: Observable<Page<UserAccountDto> | null>;

  public userAccountsTableDefinition: TableDefinition = defaultUserAccountsTableDefinition;

  private _defaultPageRequest: PageRequest = defaultPageRequest;
  public defaultSort: Sort = defaultUserAccountsSort;

  public userAccountsSearchFilter$: Observable<BasicQuerySearchFilter | null>;
  public userAccountsSearchFilter!: BasicQuerySearchFilter | null;

  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) {
    this.userAccountsSearchFilter$ = this._store
      .select(fromUserAccounts.selectUserAccountSearchFilter)
      .pipe(tap(filter => this.userAccountsSearchFilter = filter));

    this.userAccountsPage$ = this._store.select(fromUserAccounts.selectUserAccountsPage);
  }

  public onSearchFilterChanges(filter: BasicQuerySearchFilter): void {
    this._store.dispatch(fromUserAccounts.setUserAccountsSearchFilter({ filter: filter }));
    this._searchUserAccounts(filter, this._defaultPageRequest);
  }

  public onUserAccountsPageChange(pageRequest: PageRequest): void {
    this._searchUserAccounts(this.userAccountsSearchFilter, pageRequest);
  }

  private _searchUserAccounts(filter: BasicQuerySearchFilter | null, pageRequest: PageRequest): void {
    this._store.dispatch(fromUserAccounts.searchUserAccountsRequest({
      filter: filter || defaultBasicQuerySearchFilter,
      pageRequest: pageRequest
    }));
  }
}
