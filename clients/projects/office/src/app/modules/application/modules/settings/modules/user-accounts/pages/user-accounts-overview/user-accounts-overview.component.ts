import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Page, PageRequest } from '@xyz/office//modules/core/models';
import { UserAccountDto } from '@xyz/office/modules/core/dtos';
import * as fromUserAccounts from '../../store';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

@Component({
  selector: 'xyz-user-accounts-overview',
  templateUrl: './user-accounts-overview.component.html',
  styleUrls: ['./user-accounts-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsOverviewComponent implements OnInit {
  public userAccountsPage$!: Observable<Page<UserAccountDto> | null>;

  public userAccountsTableDefinition: TableDefinition = {
    title: 'User Accounts',
    columns: [
      {
        label: '',
        property: 'avatarSrc',
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
        property: 'firstName',
        type: ColumnType.TEXT,
        width: '200px'
      } as ColumnDefinition,
      {
        label: 'Last Name',
        property: 'lastName',
        type: ColumnType.TEXT,
        width: '200px'
      } as ColumnDefinition,
    ]
  } as TableDefinition

  constructor(
    private _store: Store<fromUserAccounts.UserAccountsState>
  ) { }

  ngOnInit(): void {
    this._store.dispatch(fromUserAccounts.searchUserAccountsRequest({
      pageRequest: {
        index: 0,
        size: 10
      } as PageRequest
    }));
    this.userAccountsPage$ = this._store.select(fromUserAccounts.selectUserAccountsPage);
  }

  public edit(user: UserAccountDto): void {
    console.log("Editing: ", user)
  }
}
