import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Registration } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;

  public currentStepIndex: number = 0;

  constructor(
    private _formBuilder: FormBuilder
  ) {
    this.registerForm = this._formBuilder.group({
      user: this._formBuilder.group({
        username: ['', [Validators.required]],
        password: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]]
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
  }

  public onPreviousStep(): void {
    this.currentStepIndex -= 1;
  }

  public onNextStep(): void {
    this.currentStepIndex += 1;
  }

  public onRegister(registration: Registration): void {
    alert('done!!!!');
    console.log("registration is ", registration);
    this.currentStepIndex +=1;
  }
}
