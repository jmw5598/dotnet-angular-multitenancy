import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { ResponseMessage, ResponseStatus } from '@xyz/office/modules/core/models';

@Component({
  selector: 'xyz-registration-complete',
  templateUrl: './registration-complete.component.html',
  styleUrls: ['./registration-complete.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationCompleteComponent {
  @Input()
  public message: ResponseMessage | null = null;

  public ResponseStatus = ResponseStatus;
}
