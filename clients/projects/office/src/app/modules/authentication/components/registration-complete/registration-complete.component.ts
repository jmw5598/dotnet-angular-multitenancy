import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-registration-complete',
  templateUrl: './registration-complete.component.html',
  styleUrls: ['./registration-complete.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationCompleteComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
