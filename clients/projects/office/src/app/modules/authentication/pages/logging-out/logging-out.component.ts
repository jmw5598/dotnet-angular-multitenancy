import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-logging-out',
  templateUrl: './logging-out.component.html',
  styleUrls: ['./logging-out.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class LoggingOutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
