import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-security-permissions-create',
  templateUrl: './security-permissions-create.component.html',
  styleUrls: ['./security-permissions-create.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsCreateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
