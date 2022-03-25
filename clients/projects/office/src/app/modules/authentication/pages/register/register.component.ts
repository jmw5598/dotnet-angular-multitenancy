import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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
    this.registerForm = this._formBuilder.group({});
  }

  ngOnInit(): void {
  }

  public onPreviousStep(): void {
    this.currentStepIndex -= 1;
  }

  public onNextStep(): void {
    this.currentStepIndex += 1;
  }

  public onRegister(formValue: any): void {
    alert('done!!!!');
    this.currentStepIndex +=1;
  }
}
