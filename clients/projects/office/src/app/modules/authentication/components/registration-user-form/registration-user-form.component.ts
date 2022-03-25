import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-registration-user-form',
  templateUrl: './registration-user-form.component.html',
  styleUrls: ['./registration-user-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationUserFormComponent implements OnInit {
  public formGroup: FormGroup;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('user') as FormGroup;
  }

  ngOnInit(): void {
  }
}
