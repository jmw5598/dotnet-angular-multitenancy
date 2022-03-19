import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Credentials, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable } from 'rxjs';

import * as fromAuthentication from '../../store';
import { buildLoginForm } from './login-form.builder';

@Component({
  selector: 'xyz-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;

  public loginResponseMessage$!: Observable<ResponseMessage | null>;

  constructor(
    private _store: Store<fromAuthentication.AuthenticationState>,
    private _formBuilder: FormBuilder
  ) {
    this.loginForm = buildLoginForm(this._formBuilder);
  }

  ngOnInit(): void {
    this.loginResponseMessage$ = this._store.select(fromAuthentication.selectedLoginResponseMessage);
  }

  public loginUser(credentials: Credentials): void {
    if (this.loginForm.valid) {
      console.log('submit', this.loginForm.value);
      this._store.dispatch(fromAuthentication.authenticateUserFailure({ message: { status: ResponseStatus.ERROR, message: 'Invalid username/password!'}}));
      // this._store.dispatch(
      //   fromAuthentication.authenticateUserRequest({ credentials })
      // )
    } else {
      Object.values(this.loginForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
}
