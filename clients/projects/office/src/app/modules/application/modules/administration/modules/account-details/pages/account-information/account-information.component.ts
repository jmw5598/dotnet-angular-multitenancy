import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Tenant } from '@xyz/office/modules/core/entities/multitenancy';

import * as fromRoot from '@xyz/office/store';
import * as fromTenant from '@xyz/office/store/tenant';
import { Observable } from 'rxjs';

@Component({
  selector: 'xyz-account-information',
  templateUrl: './account-information.component.html',
  styleUrls: ['./account-information.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AccountInformationComponent {
  public tenant$: Observable<Tenant | null>;

  constructor(
    private _store: Store<fromRoot.RootState>
  ) {
    this.tenant$ = this._store.select(fromTenant.selectTenant);
  }
}
