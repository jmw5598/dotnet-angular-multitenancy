import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

import { Plan } from '@xyz/office/modules/core/entities/multitenancy';

@Component({
  selector: 'xyz-registration-plan-form',
  templateUrl: './registration-plan-form.component.html',
  styleUrls: ['./registration-plan-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationPlanFormComponent {
  @Input()
  public plans: Plan[] | null = null;

  public formGroup: FormGroup;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('plan') as FormGroup;
    console.log('plans form group ', this.formGroup);
  }
}
