import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { NavigationMenuService } from '../../services/navigation-menu.service';

@Component({
  selector: 'xyz-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent implements OnInit {
  public isCollapsed$: Observable<boolean>;

  constructor(private _navigationMenuService: NavigationMenuService) {
    this.isCollapsed$ = this._navigationMenuService.isCollapsed();
  }

  ngOnInit(): void {
  }

  public onToggleNavigationMenu(): void {
    this._navigationMenuService.toggleMenu();
  }
}
