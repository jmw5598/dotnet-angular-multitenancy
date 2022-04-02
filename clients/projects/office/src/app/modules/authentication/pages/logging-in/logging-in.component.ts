import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';

@Component({
  selector: 'xyz-logging-in',
  templateUrl: './logging-in.component.html',
  styleUrls: ['./logging-in.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class LoggingInComponent implements OnInit {

  constructor(
    private _router: Router,
    private _store: Store<fromRoot.RootState>
  ) { }

  ngOnInit(): void {
    setTimeout(() => this._router.navigateByUrl('/'), 500);
    this._store.dispatch(fromUser.getUserPermissionsRequest());
    this._store.dispatch(fromUser.getUserSettingsRequest());
  }

}
