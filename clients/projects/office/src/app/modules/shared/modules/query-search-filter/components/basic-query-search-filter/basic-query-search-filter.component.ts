import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { debounceTime, distinctUntilChanged, Subject, takeUntil } from 'rxjs';

import { BasicQuerySearchFilter } from '../../models/basic-query-search-filter.model';

@Component({
  selector: 'xyz-basic-query-search-filter',
  templateUrl: './basic-query-search-filter.component.html',
  styleUrls: ['./basic-query-search-filter.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BasicQuerySearchFilterComponent implements OnInit, OnDestroy {
  private _subscriptionSubject: Subject<any> = new Subject<any>();

  @Input()
  public set filter(filter: BasicQuerySearchFilter | null) {
    if (filter) {
      this.form.patchValue({ ...filter }, { emitEvent: false });
    }
  }

  @Input()
  public debounceTime: number = 500;

  @Output()
  public searchChange: EventEmitter<BasicQuerySearchFilter> = new EventEmitter<BasicQuerySearchFilter>();

  public form: FormGroup;

  constructor() {
    this.form = new FormGroup({
      query: new FormControl('')
    });
  }

  ngOnInit(): void {
    this._listenForSearchQueryChanges();
  }

  public onSearch(filter: BasicQuerySearchFilter): void {
    this.searchChange.emit(filter);
  }

  private _listenForSearchQueryChanges(): void {
    this.form.valueChanges
      .pipe(
        takeUntil(this._subscriptionSubject),
        distinctUntilChanged(),
        debounceTime(this.debounceTime)
      )
      .subscribe((filter: BasicQuerySearchFilter) => this.searchChange.emit(filter));
  }

  ngOnDestroy(): void {
    this._subscriptionSubject.next(null);
    this._subscriptionSubject.complete();
  }
}
