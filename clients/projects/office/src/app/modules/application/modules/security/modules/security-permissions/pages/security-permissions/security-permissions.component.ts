import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';

import { Page, PageRequest, Sort } from '@xyz/office/modules/core/models';
import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { TableDefinition } from '@xyz/office/modules/shared/modules/datatable';
import { TemplateModulePermissionName } from '@xyz/office/modules/core/entities/tenants';
import { defaultBasicQuerySearchFilter, defaultPageRequest } from '@xyz/office/modules/core/constants';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';

import * as fromSecurityPermissions from '../../store';
import { defaultSecurityPermissionsSort } from '../../constants/sort.defaults';
import { defaultSecurityPermissionsTableDefinition } from './security-permissions-table-definition.defaults';

@Component({
  selector: 'xyz-security-permissions',
  templateUrl: './security-permissions.component.html',
  styleUrls: ['./security-permissions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class SecurityPermissionsComponent {

  public securityPermissionsTemplatePage$!: Observable<Page<TemplateModulePermissionName> | null>;

  public securityPermissionsTemplateTableDefinition: TableDefinition = defaultSecurityPermissionsTableDefinition;

  private _defaultPageRequest: PageRequest = defaultPageRequest;
  public defaultSort: Sort = defaultSecurityPermissionsSort;

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

  public onSecurityPermissionsPageChange(pageRequest: PageRequest): void {
    this._searchTemplateModulePermissions(this.templateModulePermissionsSearchFilter, pageRequest);
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
