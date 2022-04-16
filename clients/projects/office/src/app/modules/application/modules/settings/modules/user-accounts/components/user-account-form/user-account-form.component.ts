import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Permission } from '@xyz/office/modules/core/entities';
import { XyzDatatableSettings } from '@xyz/office/modules/shared/modules/datatable';

@Component({
  selector: 'xyz-user-account-form',
  templateUrl: './user-account-form.component.html',
  styleUrls: ['./user-account-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserAccountFormComponent implements OnInit {
  @Input()
  public assignablePermissions: Permission[] | null = null;

  public userAccountForm!: FormGroup;

  public tableSettings: XyzDatatableSettings = {
    bordered: true,
    size: 'middle'
  };

  constructor(
    private _controlContainer: ControlContainer
  ) { }

  ngOnInit(): void {
    this.userAccountForm = this._controlContainer.control as FormGroup;
  }
}
