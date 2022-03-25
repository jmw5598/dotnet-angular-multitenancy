import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-registration-plan-form',
  templateUrl: './registration-plan-form.component.html',
  styleUrls: ['./registration-plan-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationPlanFormComponent implements OnInit {
  public formGroup: FormGroup;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('plan') as FormGroup;
  }

  ngOnInit(): void {
  }
}
