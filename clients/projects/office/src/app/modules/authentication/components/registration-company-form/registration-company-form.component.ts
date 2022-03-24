import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-registration-company-form',
  templateUrl: './registration-company-form.component.html',
  styleUrls: ['./registration-company-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationCompanyFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
