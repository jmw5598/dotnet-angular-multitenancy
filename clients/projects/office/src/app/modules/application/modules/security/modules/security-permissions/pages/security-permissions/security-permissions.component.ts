import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Page, PageRequest } from '@xyz/office/modules/core/models';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'xyz-security-permissions',
  templateUrl: './security-permissions.component.html',
  styleUrls: ['./security-permissions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsComponent implements OnInit {

  public securityPermissionsTemplatePage$: Observable<Page<any>> = of({
    elements: [],
    totalElements: 0,
    totalPages: 0,
    current: PageRequest.from(0, 15, '', 'desc'),
    next: PageRequest.from(0, 15, '', 'desc'),
    previous: PageRequest.from(0, 15, '', 'desc')
  } as Page<any>);

  public securityPermissionsTemplateTableDefinition: TableDefinition = {
    title: 'Named Template Permisssions',
    columns: [
      {
        label: 'Name',
        property: 'name',
        type: ColumnType.TEXT,
        width: '400px'
      } as ColumnDefinition,
      {
        label: 'Description',
        property: 'description',
        type: ColumnType.TEXT
      } as ColumnDefinition,
      {
        label: 'Create On',
        property: 'createOn',
        type: ColumnType.DATE,
        width: '200px'
      } as ColumnDefinition,
      {
        label: 'Updated On',
        property: 'updatedOn',
        type: ColumnType.DATE,
        width: '200px'
      } as ColumnDefinition
    ]
  } as TableDefinition

  constructor() { }

  ngOnInit(): void {
  }

}
