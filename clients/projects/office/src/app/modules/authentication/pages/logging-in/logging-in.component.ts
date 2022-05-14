import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';
import { combineLatest, filter, take } from 'rxjs';

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
    this._dispatchActionsForUserSettingsAndPermissions();
    this._listenForUserSettingsAndPermissionsResolution();
  }

  private _dispatchActionsForUserSettingsAndPermissions(): void {
    this._store.dispatch(fromUser.getUserPermissionsRequest());
    this._store.dispatch(fromUser.getUserSettingsRequest());
  }

  private _listenForUserSettingsAndPermissionsResolution(): void {
    combineLatest([
      this._store.select(fromUser.selectUserSettings),
      this._store.select(fromUser.selectUserModulePermissionsMap)
    ])
    .pipe(
      filter(([settings, permissions]) => !!settings && !!permissions),
      take(1)
    )
    .subscribe(([settings, permissions]) => this._router.navigateByUrl('/'));
  }
}
