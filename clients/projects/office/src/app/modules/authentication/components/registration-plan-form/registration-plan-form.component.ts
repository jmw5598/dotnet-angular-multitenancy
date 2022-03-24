import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-registration-plan-form',
  templateUrl: './registration-plan-form.component.html',
  styleUrls: ['./registration-plan-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationPlanFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
