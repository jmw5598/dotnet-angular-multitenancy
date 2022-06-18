import { Component, ChangeDetectionStrategy } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class InventoryComponent {
  constructor() { }
}
