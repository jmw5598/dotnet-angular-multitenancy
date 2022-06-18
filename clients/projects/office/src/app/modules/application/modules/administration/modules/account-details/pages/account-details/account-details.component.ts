import { Component, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { TabNavigationLink, TenantStatistics } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

import { defaultAccountDetailsNavigationLinks } from './account-details-navigation-links.defaults';

import * as fromAccountDetails from '../../store/account-details';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'xyz-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class AccountDetailsComponent implements OnDestroy {
  public defaultAccountDetailsNavigationLinks: TabNavigationLink[] = defaultAccountDetailsNavigationLinks

  public tenantStatistics$: Observable<TenantStatistics | null>;

  constructor(
    private _store: Store<fromAccountDetails.AccountDetailsState>
  ) {
    this.tenantStatistics$ = this._store.select(fromAccountDetails.selectTenantStatistics);
  }

  ngOnDestroy(): void {
    this._store.dispatch(
      fromAccountDetails.setTenantStatistics({ 
        tenantStatistics: null
      })
    );
  }
}
