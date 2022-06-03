import { Component, OnInit, ChangeDetectionStrategy, Input, TemplateRef, EventEmitter, Output } from '@angular/core';

import { Page, PageRequest, Sort, SortDirection } from '@xyz/office/modules/core/models';
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

  @Input()
  public defaultSort: Sort = {
    column: 'id',
    direction: SortDirection.Descend
  } as Sort;

  public get settings(): XyzDatatableSettings {
    return this._settings;
  }

  @Input()
  public actionsContent: TemplateRef<any> | null = null;

  @Input()
  public actionsWidth: string | null = '150px';

  @Output()
  public onPageChange: EventEmitter<PageRequest> = new EventEmitter<PageRequest>();

  public ColumnType = ColumnType;
  public SortDirection = SortDirection;

  constructor() { }

  ngOnInit(): void {
  }

  public pageIndexChanged(page: number): void {
    this.onPageChange.emit({
      index: page - 1,
      size: this.page?.current?.size || 10,
      sort: this.page?.current?.sort 
        ? { ...this.page.current.sort} as Sort 
        : null
    } as PageRequest);
  }

  public pageSizeChanged(size: number): void {
    this.onPageChange.emit({
      index: 0,
      size: size || 20,
      sort: this.page?.current?.sort 
        ? { ...this.page.current.sort} as Sort 
        : this.defaultSort
    } as PageRequest);
  }

  public sortOrderChanged(column: string, direction: string | null): void {
    console.log("direction is ", direction);
    const sortDirection: SortDirection | null = direction ? (direction === 'ascend' ? SortDirection.Ascend : SortDirection.Descend) : null;
    
    this.onPageChange.emit({
      index: 0, 
      size: this.page?.current?.size || 10,
      sort: sortDirection 
        ? { column: column, direction: sortDirection } 
        : this.defaultSort
    });
  }
}
