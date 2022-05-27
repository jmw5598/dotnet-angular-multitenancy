import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'xyz-template-module-permission-name-update-form',
  templateUrl: './template-module-permission-name-update-form.component.html',
  styleUrls: ['./template-module-permission-name-update-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TemplateModulePermissionNameUpdateFormComponent implements OnInit {
  public templateModulePermissionNameForm!: FormGroup;

  constructor(
    private _controlContainer: ControlContainer
  ) { }

  ngOnInit(): void {
    this.templateModulePermissionNameForm = this._controlContainer?.control as FormGroup;
  }
}
