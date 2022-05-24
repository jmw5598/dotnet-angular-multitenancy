import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'xyz-template-module-permission-name-update-form',
  templateUrl: './template-module-permission-name-update-form.component.html',
  styleUrls: ['./template-module-permission-name-update-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TemplateModulePermissionNameUpdateFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
