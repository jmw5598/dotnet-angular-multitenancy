import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Credentials, ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';
import { ClientSettings, EnvironmentService } from '@xyz/office/modules/core/services';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable } from 'rxjs';

import * as fromAuthentication from '../../store';

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
    private _environmentService: EnvironmentService,
    private _store: Store<fromAuthentication.AuthenticationState>,
    private _formBuilder: FormBuilder
  ) {
    this.loginForm = this._buildLoginForm();
  }

  ngOnInit(): void {
    this.loginResponseMessage$ = this._store.select(fromAuthentication.selectedLoginResponseMessage);
  }

  public get findCompanyUrl(): string {
    const client: ClientSettings = this._environmentService.getSection("client");
    return `${client.protocol}://${client.domain}${ client?.port ? ':' + client.port : ''}`;
  }

  public onLoginUser(credentials: Credentials): void {
    if (this.loginForm.valid) {
      this._store.dispatch(fromAuthentication.loginUserRequest({ credentials }))
    } else {
      Object.values(this.loginForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  private _buildLoginForm(): FormGroup {
    return this._formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      rememberMe: [false, [Validators.required]]
    });
  }
}
