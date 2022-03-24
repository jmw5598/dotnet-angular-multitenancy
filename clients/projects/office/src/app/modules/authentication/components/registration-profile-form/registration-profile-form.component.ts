import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-registration-profile-form',
  templateUrl: './registration-profile-form.component.html',
  styleUrls: ['./registration-profile-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationProfileFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
