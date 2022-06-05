import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Store } from '@ngrx/store';
import { debounceTime, Observable, Subject, takeUntil } from 'rxjs';
import { NzAutocompleteOptionComponent } from 'ng-zorro-antd/auto-complete';

import { fadeAnimation } from '@xyz/office/modules/shared/animations';
import { Page, PageRequest } from '@xyz/office/modules/core/models';
import { Tenant } from '@xyz/office/modules/core/entities';
import { BasicQuerySearchFilter } from '@xyz/office/modules/shared/modules/query-search-filter';
import { defaultPageRequest } from '@xyz/office/modules/core/constants';
import { ClientSettings, EnvironmentService } from '@xyz/office/modules/core/services';

import * as fromAuthentication from '../../store';

@Component({
  selector: 'xyz-company-search',
  templateUrl: './company-search.component.html',
  styleUrls: ['./company-search.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [fadeAnimation]
})
export class CompanySearchComponent implements OnInit, OnDestroy {
  private _destroy$: Subject<any> = new Subject<any>();
  private _companySearchSubject$: Subject<BasicQuerySearchFilter> = new Subject<BasicQuerySearchFilter>();
  public selectedCompany = null;

  public searchCompaniesPage$: Observable<Page<Tenant> | null>;
  public defaultSearchCompaniesPageRequest: PageRequest = defaultPageRequest;

  constructor(
    @Inject(DOCUMENT)
    private _document: Document,
    private _environmentService: EnvironmentService,
    private _store: Store<fromAuthentication.AuthenticationState>
  ) {
    this.searchCompaniesPage$ = this._store.select(fromAuthentication.selectSearchCompaniesPage);
  }

  ngOnInit(): void {
    this._listenForCompanySearchDebounce();
  }

  public onSearch(event: any): void {
    this.selectedCompany = null;
    const searchQuery: string = event?.target?.value?.trim() || '';
    this._companySearchSubject$.next({ query: searchQuery } as BasicQuerySearchFilter);
  }

  public onSelection(option: NzAutocompleteOptionComponent): void {
    this.selectedCompany = option.nzValue;
  }

  public onLoginToCompany(tenant: Tenant | null): void {
    if (!tenant) return;
    
    const client: ClientSettings = this._environmentService.getSection('client');
    const redirectUrl: string = `${client.protocol}://${tenant.name}.${client.domain}${ client?.port ? ':' + client.port : ''}`;
    
    this._document.location.href = redirectUrl;
  }

  private _listenForCompanySearchDebounce(): void {
    this._companySearchSubject$
      .pipe(
        takeUntil(this._destroy$),
        debounceTime(500)
      )
      .subscribe((filter: BasicQuerySearchFilter) => {
        if (filter?.query?.trim().length) {
          this._store.dispatch(fromAuthentication.searchCompaniesRequest({
            filter: filter,
            pageRequest: defaultPageRequest
          }));
        } else {
          this._store.dispatch(fromAuthentication.setSearchCompaniesPage({ page: null }));
        }
        
      })
  }

  ngOnDestroy(): void {
    this._companySearchSubject$.complete();
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
