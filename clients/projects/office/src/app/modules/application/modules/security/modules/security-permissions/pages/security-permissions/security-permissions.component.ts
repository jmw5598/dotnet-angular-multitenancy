import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';

import { Page, PageRequest } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';

import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromSecurityPermissions from '../../store';

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

  private _defaultSearchFilter: BasicQuerySearchFilter = {
    query: ''
  } as BasicQuerySearchFilter;

  private _defaultPageRequest: PageRequest = {
    index: 0,
    size: 10
  } as PageRequest;

  constructor(
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
  ) { }

  ngOnInit(): void {
    this._store.dispatch(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest({
      filter: this._defaultSearchFilter,
      pageRequest: this._defaultPageRequest 
    }));
    this.securityPermissionsTemplatePage$ = this._store.select(fromSecurityPermissions.selectTemplateModulePermissionNamesPage);
  }

  public onSearchFilterChanges(filter: BasicQuerySearchFilter): void {
    this._store.dispatch(fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest({
      filter: filter,
      pageRequest: this._defaultPageRequest
    }));
  }
}
