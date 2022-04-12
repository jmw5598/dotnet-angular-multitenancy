import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsCreateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
