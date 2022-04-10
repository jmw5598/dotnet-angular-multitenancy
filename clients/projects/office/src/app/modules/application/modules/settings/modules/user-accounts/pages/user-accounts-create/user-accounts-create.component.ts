import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-user-accounts-create',
  templateUrl: './user-accounts-create.component.html',
  styleUrls: ['./user-accounts-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountsCreateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
