import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-user-accounts-update',
  templateUrl: './user-accounts-update.component.html',
  styleUrls: ['./user-accounts-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountsUpdateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
