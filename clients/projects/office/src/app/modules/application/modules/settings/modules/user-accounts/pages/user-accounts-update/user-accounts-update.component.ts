import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-user-accounts-update',
  templateUrl: './user-accounts-update.component.html',
  styleUrls: ['./user-accounts-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class UserAccountsUpdateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
