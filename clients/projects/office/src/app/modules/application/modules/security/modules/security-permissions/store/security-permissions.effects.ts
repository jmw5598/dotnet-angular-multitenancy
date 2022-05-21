import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';

import * as fromSecurityPermissions from './security-permissions.actions';

@Injectable()
export class SecurityPermissionsEffects {
  constructor(
    private _actions: Actions
  ) { }
}