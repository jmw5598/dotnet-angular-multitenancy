import { Component, ChangeDetectionStrategy } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SettingsComponent {
  constructor() { }
}
