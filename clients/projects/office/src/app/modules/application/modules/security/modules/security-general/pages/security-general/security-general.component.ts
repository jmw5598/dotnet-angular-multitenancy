import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-security-general',
  templateUrl: './security-general.component.html',
  styleUrls: ['./security-general.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityGeneralComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
