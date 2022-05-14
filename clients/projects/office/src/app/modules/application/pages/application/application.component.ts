import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { NavigationLink, UserModulesAndPermissionsMap, UserSettings } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { defaultNavigationMenu } from '../../constants/navigation-menu.defaults';
import { NavigationMenuService } from '../../services/navigation-menu.service';

import * as fromRoot from '@xyz/office/store';
import * as fromUser from '@xyz/office/store/user';

@Component({
  selector: 'xyz-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class ApplicationComponent implements OnInit {
  public isCollapsed$: Observable<boolean>;
  public defaultNavigationMenu: NavigationLink[] = defaultNavigationMenu;

  public userSettings$: Observable<UserSettings | null>;

  public userModulePermissionsMap$!: Observable<UserModulesAndPermissionsMap | null>;

  constructor(
    private _navigationMenuService: NavigationMenuService,
    private _store: Store<fromRoot.RootState>
  ) {
    this.isCollapsed$ = this._navigationMenuService.isCollapsed();
    this.userModulePermissionsMap$ = this._store.select(fromUser.selectUserModulePermissionsMap);
    this.userSettings$ = this._store.select(fromUser.selectUserSettings);
  }

  ngOnInit(): void {
  }

  public onToggleNavigationMenu(): void {
    this._navigationMenuService.toggleMenu();
  }
}
