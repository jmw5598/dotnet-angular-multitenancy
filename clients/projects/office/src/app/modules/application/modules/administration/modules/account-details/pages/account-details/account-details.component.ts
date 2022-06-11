import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NavigationLink, TabNavigationLink } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

import { defaultAccountDetailsNavigationLinks } from './account-details-navigation-links.defaults';

@Component({
  selector: 'xyz-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class AccountDetailsComponent implements OnInit {
  public defaultAccountDetailsNavigationLinks: TabNavigationLink[] = defaultAccountDetailsNavigationLinks

  constructor() { }

  ngOnInit(): void {
  }

  tabs = ['Tab 1', 'Tab 2'];
  selectedIndex = 0;

  closeTab({ index }: { index: number }): void {
    this.tabs.splice(index, 1);
  }

  newTab(): void {
    this.tabs.push('New Tab');
    this.selectedIndex = this.tabs.length;
  }
}
