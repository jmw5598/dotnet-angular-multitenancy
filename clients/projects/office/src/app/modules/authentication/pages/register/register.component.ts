import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Registration, ResponseMessage } from '@xyz/office/modules/core/models';
import { MatchValidators } from '@xyz/office/modules/core/validators';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable } from 'rxjs';

import * as fromAuthentication from '../../store';

@Component({
  selector: 'xyz-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class RegisterComponent implements OnInit, OnDestroy {
  public registerForm: FormGroup;

  public currentStepIndex: number = 0;

  public registrationResponseMessage$!: Observable<ResponseMessage | null>;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromAuthentication.AuthenticationState>
  ) {
    this.registerForm = this._formBuilder.group({
      user: this._formBuilder.group({
        username: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]]
      }, { 
        validators: MatchValidators.mustMatch('password', 'confirmPassword') 
      }),
      profile: this._formBuilder.group({
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]]
      }),
      company: this._formBuilder.group({
        name: ['', [Validators.required]]
      }),
      plan: this._formBuilder.group({
        id: [null, [Validators.required]]
      })
    });
  }

  ngOnInit(): void {
    this.registrationResponseMessage$ = this._store.select(fromAuthentication.selectRegistartionResponseMessage);
  }

  public onPreviousStep(): void {
    this.currentStepIndex -= 1;
  }

  public onNextStep(): void {
    this.currentStepIndex += 1;
  }

  public onRegister(registration: Registration): void {
    this._store.dispatch(fromAuthentication.registrationRequest({ registration: registration }));
    this.currentStepIndex +=1;
  }

  ngOnDestroy(): void {
    this.registerForm.reset();
    this._store.dispatch(fromAuthentication.setRegistrationResponseMessage({ message: null }));
  }
}
