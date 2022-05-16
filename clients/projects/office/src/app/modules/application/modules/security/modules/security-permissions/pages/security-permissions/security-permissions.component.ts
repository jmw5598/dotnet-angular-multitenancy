import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-security-permissions',
  templateUrl: './security-permissions.component.html',
  styleUrls: ['./security-permissions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
