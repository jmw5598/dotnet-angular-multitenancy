import { Component, ChangeDetectionStrategy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-registration-profile-form',
  templateUrl: './registration-profile-form.component.html',
  styleUrls: ['./registration-profile-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationProfileFormComponent {
  public formGroup: FormGroup;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('profile') as FormGroup;
  }
}
