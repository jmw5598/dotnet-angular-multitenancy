import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { NavigationLink, UserPermissionsMap } from '@xyz/office/modules/core/models';
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

  public userPermissionsMap$!: Observable<UserPermissionsMap | null>;

  constructor(
    private _navigationMenuService: NavigationMenuService,
    private _store: Store<fromRoot.RootState>
  ) {
    this.isCollapsed$ = this._navigationMenuService.isCollapsed();
    this.userPermissionsMap$ = this._store.select(fromUser.selectUserPermissionsMap);
  }

  ngOnInit(): void {
  }

  public onToggleNavigationMenu(): void {
    this._navigationMenuService.toggleMenu();
  }
}
