import { Component, ChangeDetectionStrategy } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class DashboardComponent {
  constructor() { }
}
