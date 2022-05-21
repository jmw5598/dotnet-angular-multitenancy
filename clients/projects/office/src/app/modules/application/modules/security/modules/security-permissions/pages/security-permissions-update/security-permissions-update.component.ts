import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-security-permissions-update',
  templateUrl: './security-permissions-update.component.html',
  styleUrls: ['./security-permissions-update.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsUpdateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
