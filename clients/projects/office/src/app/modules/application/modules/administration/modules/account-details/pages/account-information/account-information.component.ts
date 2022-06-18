import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-account-information',
  templateUrl: './account-information.component.html',
  styleUrls: ['./account-information.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AccountInformationComponent {
  constructor() { }
}
