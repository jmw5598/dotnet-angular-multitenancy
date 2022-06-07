import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';

import { Registration, ResponseMessage } from '@xyz/office/modules/core/models';
import { MatchValidators, UserValidators, ValidationPatterns } from '@xyz/office/modules/core/validators';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Observable } from 'rxjs';

import * as fromAuthentication from '../../store';
import * as fromPlans from '@xyz/office/store/plans';
import * as fromRoot from '@xyz/office/store';
import { Plan } from '@xyz/office/modules/core/entities';
import { ClientSettings, EnvironmentService } from '@xyz/office/modules/core/services';

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
  public availablePlans$!: Observable<Plan[] | null>;

  public clientSettings: ClientSettings;

  constructor(
    private _formBuilder: FormBuilder,
    private _store: Store<fromRoot.RootState>,
    private _userValidators: UserValidators,
    private _environmentService: EnvironmentService
  ) {
    this.clientSettings = this._environmentService.getSection('client');
    
    this.registerForm = this._formBuilder.group({
      user: this._formBuilder.group({
        username: ['', [
          Validators.required, 
          Validators.email
        ]],
        password: ['', [
          Validators.required,
          Validators.minLength(6),
          Validators.pattern(ValidationPatterns.password)
        ]],
        confirmPassword: ['', [
          Validators.required,
          Validators.minLength(6),
          Validators.pattern(ValidationPatterns.password)
        ]]
      }, { 
        validators: MatchValidators.mustMatch('password', 'confirmPassword') 
      }),
      profile: this._formBuilder.group({
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]]
      }),
      company: this._formBuilder.group({
        name: ['', [Validators.required]],
        subdomain: ['', [Validators.required]]
      }),
      plan: this._formBuilder.group({
        id: [null, [Validators.required]]
      })
    });
  }

  ngOnInit(): void {
    this.registrationResponseMessage$ = this._store.select(fromAuthentication.selectRegistartionResponseMessage);
    this.availablePlans$ = this._store.select(fromPlans.selectAvailablePlans);
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
