import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-registration-company-form',
  templateUrl: './registration-company-form.component.html',
  styleUrls: ['./registration-company-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationCompanyFormComponent implements OnInit {
  public formGroup: FormGroup;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('company') as FormGroup;
  }

  ngOnInit(): void {
  }
}
