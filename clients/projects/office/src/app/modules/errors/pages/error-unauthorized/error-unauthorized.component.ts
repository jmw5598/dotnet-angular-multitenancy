import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-error-unauthorized',
  templateUrl: './error-unauthorized.component.html',
  styleUrls: ['./error-unauthorized.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorUnauthorizedComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
