import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Page, PageRequest } from '@xyz/office//modules/core/models';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromUserAccounts from '../../store';

@Component({
  selector: 'xyz-user-accounts-overview',
  templateUrl: './user-accounts-overview.component.html',
  styleUrls: ['./user-accounts-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsOverviewComponent {
  public userAccountsPage$!: Observable<Page<UserAccountDto> | null>;

  public userAccountsTableDefinition: TableDefinition = {
    title: 'User Accounts',
    columns: [
      {
        label: '',
        property: 'avatarUrl',
        type: ColumnType.IMAGE,
        width: '75px'
      },
      {
        label: 'User Name',
        property: 'userName',
        type: ColumnType.TEXT,
        width: '200px'

      } as ColumnDefinition,
      {
        label: 'Email',
        property: 'email',
        type: ColumnType.EMAIL,
        width: '200px'
      } as ColumnDefinition,
      {
        label: 'First name',
        property: 'profile.firstName',
        type: ColumnType.TEXT,
        width: '200px'
      } as ColumnDefinition,
      {
        label: 'Last Name',
        property: 'profile.lastName',
        type: ColumnType.TEXT,
        width: '200px'
      } as ColumnDefinition,
    ]
  } as TableDefinition

  private _defaultPageRequest: PageRequest = defaultPageRequest;

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

  private _searchUserAccounts(filter: BasicQuerySearchFilter | null, pageRequest: PageRequest): void {
    this._store.dispatch(fromUserAccounts.searchUserAccountsRequest({
      filter: filter || defaultBasicQuerySearchFilter,
      pageRequest: pageRequest
    }));
  }

  public edit(user: UserAccountDto): void {
    console.log("Editing: ", user)
  }
}
