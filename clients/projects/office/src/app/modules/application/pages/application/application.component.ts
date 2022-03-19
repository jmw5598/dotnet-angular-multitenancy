import { Component, OnInit } from '@angular/core';
import { NavigationLink } from '@xyz/office/modules/core/models';
import { Observable } from 'rxjs';
import { defaultNavigationMenu } from '../../constants/navigation-menu.defaults';
import { NavigationMenuService } from '../../services/navigation-menu.service';

@Component({
  selector: 'xyz-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent implements OnInit {
  public isCollapsed$: Observable<boolean>;

  public defaultNavigationMenu: NavigationLink[] = defaultNavigationMenu;

  constructor(private _navigationMenuService: NavigationMenuService) {
    this.isCollapsed$ = this._navigationMenuService.isCollapsed();
  }

  ngOnInit(): void {
  }

  public onToggleNavigationMenu(): void {
    this._navigationMenuService.toggleMenu();
  }
}
