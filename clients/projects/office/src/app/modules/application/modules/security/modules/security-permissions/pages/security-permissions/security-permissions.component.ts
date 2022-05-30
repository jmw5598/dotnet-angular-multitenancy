import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';

import { Page, PageRequest } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { ColumnDefinition, ColumnType, TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromSecurityPermissions from '../../store';

@Component({
  selector: 'xyz-security-permissions',
  templateUrl: './security-permissions.component.html',
  styleUrls: ['./security-permissions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsComponent {

  public securityPermissionsTemplatePage$!: Observable<Page<TemplateModulePermissionName> | null>;

  public securityPermissionsTemplateTableDefinition: TableDefinition = {
    title: 'Named Template Permisssions',
    columns: [
      {
        label: 'Name',
        property: 'name',
        type: ColumnType.TEXT,
        width: '300px'
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
        width: '125px'
      } as ColumnDefinition,
      {
        label: 'Created By',
        property: 'createdBy.userName',
        type: ColumnType.EMAIL,
        width: '200px'
      } as ColumnDefinition,
      {
        label: 'Updated On',
        property: 'updatedOn',
        type: ColumnType.DATE,
        width: '125px'
      } as ColumnDefinition,
      {
        label: 'Updated By',
        property: 'updatedBy.userName',
        type: ColumnType.EMAIL,
        width: '200px'
      } as ColumnDefinition,
    ]
  } as TableDefinition

  private _defaultPageRequest: PageRequest = defaultPageRequest;

  public templateModulePermissionsSearchFilter$: Observable<BasicQuerySearchFilter | null>;
  public templateModulePermissionsSearchFilter!: BasicQuerySearchFilter | null;

  constructor(
    private _store: Store<fromSecurityPermissions.SecurityPermissionsState>
  ) {
    this.templateModulePermissionsSearchFilter$ = this._store
      .select(fromSecurityPermissions.selectTemplateModulePermissionSearchFilter)
      .pipe(tap(filter => this.templateModulePermissionsSearchFilter = filter));

    this.securityPermissionsTemplatePage$ = this._store
      .select(fromSecurityPermissions.selectTemplateModulePermissionNamesPage);
  }

  public onSearchFilterChanges(filter: BasicQuerySearchFilter): void {
    this._store.dispatch(
      fromSecurityPermissions.setTemplateModulePermissionsSearchFilter({ 
        filter : filter
      })
    );
    this._searchTemplateModulePermissions(filter, this._defaultPageRequest);
  }

  public onDeleteTemplateModulePermissionName(templateModulePermissionName: TemplateModulePermissionName): void {
    this._store.dispatch(
      fromSecurityPermissions.deleteTemplateModulePermissionNameRequest({
        templateModulePermissionNameId: templateModulePermissionName.id
      })
    )
  }

  private _searchTemplateModulePermissions(filter: BasicQuerySearchFilter | null, pageRequest: PageRequest): void {
    this._store.dispatch(
      fromSecurityPermissions.searchTemplateModulePerrmissionNamesRequest({
        filter: filter || defaultBasicQuerySearchFilter,
        pageRequest: pageRequest
      })
    );
  }
}
