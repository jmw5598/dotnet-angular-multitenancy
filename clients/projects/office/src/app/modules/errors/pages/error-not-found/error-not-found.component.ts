import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-error-not-found',
  templateUrl: './error-not-found.component.html',
  styleUrls: ['./error-not-found.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorNotFoundComponent {
  constructor() { }
}
