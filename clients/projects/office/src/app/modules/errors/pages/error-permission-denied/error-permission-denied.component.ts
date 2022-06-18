import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-error-permission-denied',
  templateUrl: './error-permission-denied.component.html',
  styleUrls: ['./error-permission-denied.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorPermissionDeniedComponent {
  constructor() { }
}
