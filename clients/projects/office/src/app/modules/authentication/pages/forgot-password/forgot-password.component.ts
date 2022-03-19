import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { PasswordReset, ResponseMessage } from '@xyz/office/modules/core/models';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable } from 'rxjs';

import * as fromAuthentication from '../../store';

@Component({
  selector: 'xyz-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class ForgotPasswordComponent implements OnInit {
  public forgotPasswordForm: FormGroup;

  public passwordResetRequestResponseMessage$!: Observable<ResponseMessage | null>;

  constructor(
    private _store: Store<fromAuthentication.AuthenticationState>,
    private _formBuilder: FormBuilder
  ) {
    this.forgotPasswordForm = this._buildForgotPasswordForm();
  }

  ngOnInit(): void {
    this.passwordResetRequestResponseMessage$ = this._store.select(fromAuthentication.selectedPasswordResetRequestResponseMessage)
  }

  public onForgotPasswordRequest(request: PasswordReset): void {
    if (this.forgotPasswordForm.valid) {
      this._store.dispatch(fromAuthentication.passwordResetRequest({ request }));
    } else {
      Object.values(this.forgotPasswordForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  private _buildForgotPasswordForm(): FormGroup {
    return this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    })
  }
}
