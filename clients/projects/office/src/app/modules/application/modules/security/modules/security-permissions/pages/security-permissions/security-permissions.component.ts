import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of, tap } from 'rxjs';

import { BasicQuerySearchFilter, Page, PageRequest } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';

import * as fromSecurityPermissions from '../../store';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

@Component({
  selector: 'xyz-security-permissions',
  templateUrl: './security-permissions.component.html',
  styleUrls: ['./security-permissions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsComponent implements OnInit {

  public securityPermissionsTemplatePage$!: Observable<Page<TemplateModulePermissionName> | null>;

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
        type: ColumnType.TEXT,
        width: '400px'
      } as ColumnDefinition,
      {
        label: 'Created On',
        property: 'createdOn',
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

  constructor(
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
  ) { }

  ngOnInit(): void {
    this._store.dispatch(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest({
      filter: {
        query: ''
      } as BasicQuerySearchFilter,
      pageRequest: {
        index: 0,
        size: 10
      } as PageRequest
    }));
    this.securityPermissionsTemplatePage$ = this._store.select(fromSecurityPermissions.selectTemplateModulePermissionNamesPage);
  }
}
