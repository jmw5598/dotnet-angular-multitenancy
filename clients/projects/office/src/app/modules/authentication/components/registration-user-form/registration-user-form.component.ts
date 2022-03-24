import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-registration-user-form',
  templateUrl: './registration-user-form.component.html',
  styleUrls: ['./registration-user-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationUserFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
