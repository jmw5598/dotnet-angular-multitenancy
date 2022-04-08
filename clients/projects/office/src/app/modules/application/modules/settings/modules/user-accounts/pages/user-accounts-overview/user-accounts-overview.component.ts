import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Page, PageRequest } from '@xyz/office//modules/core/models';
import { UserDto } from '@xyz/office/modules/core/dtos';
import * as fromUserAccounts from '../../store';

@Component({
  selector: 'xyz-user-accounts-overview',
  templateUrl: './user-accounts-overview.component.html',
  styleUrls: ['./user-accounts-overview.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsOverviewComponent implements OnInit {
  public userAccountsPage$!: Observable<Page<UserDto> | null>;

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
}
