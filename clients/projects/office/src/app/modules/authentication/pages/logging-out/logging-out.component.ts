import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { filter, from, take } from 'rxjs';

import * as fromAuthentication from '../../store';

@Component({
  selector: 'xyz-logging-out',
  templateUrl: './logging-out.component.html',
  styleUrls: ['./logging-out.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class LoggingOutComponent implements OnInit {
  constructor(
    private _store: Store<fromAuthentication.AuthenticationState>,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this._store.dispatch(fromAuthentication.logoutUserRequest());
    this._store.select(fromAuthentication.selectAuthenticatedUser)
      .pipe(take(1))
      .subscribe(authenticatedUser => {
        setTimeout(() => this._router.navigateByUrl('/auth/login'), 500);
      });
  }
}
