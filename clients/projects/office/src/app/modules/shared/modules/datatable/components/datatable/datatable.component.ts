import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

import { Page } from '@xyz/office/modules/core/models';

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


  constructor() { }

  ngOnInit(): void {
  }

}
