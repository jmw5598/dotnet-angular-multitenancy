import { Component, OnInit, ChangeDetectionStrategy, Input, TemplateRef } from '@angular/core';

import { Page } from '@xyz/office/modules/core/models';
import { ColumnType } from '../../models/column-type.enum';

import { DEFAULT_XYZ_DATATABLE_SETTINGS, XyzDatatableSettings } from '../../models/datatable-settings.model';
import { TableDefinition } from '../../models/table-definition.model';

@Component({
  selector: 'xyz-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class XyzDatatableComponent implements OnInit {
  @Input()
  public definition: TableDefinition | null = null;

  @Input()
  public page: Page<any> | null = null;

  private _settings: XyzDatatableSettings = DEFAULT_XYZ_DATATABLE_SETTINGS;

  @Input()
  public set settings(settings: XyzDatatableSettings) {
    this._settings = {
      ...DEFAULT_XYZ_DATATABLE_SETTINGS,
      ...settings
    } as XyzDatatableSettings;
  }

  public get settings(): XyzDatatableSettings {
    return this._settings;
  }

  @Input()
  public actionsContent: TemplateRef<any> | null = null;

  public ColumnType = ColumnType;

  constructor() { }

  ngOnInit(): void {
  }

}
