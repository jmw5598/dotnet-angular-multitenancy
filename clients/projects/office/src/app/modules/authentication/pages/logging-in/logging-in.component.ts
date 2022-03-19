import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';

@Component({
  selector: 'xyz-logging-in',
  templateUrl: './logging-in.component.html',
  styleUrls: ['./logging-in.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class LoggingInComponent implements OnInit {

  constructor(private _router: Router) { }

  ngOnInit(): void {
    setTimeout(() => this._router.navigateByUrl('/'), 500);
  }

}
