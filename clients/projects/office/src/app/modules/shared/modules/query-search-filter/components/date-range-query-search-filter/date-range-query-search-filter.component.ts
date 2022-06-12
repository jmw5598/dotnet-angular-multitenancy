import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { debounceTime, distinctUntilChanged, Subject, takeUntil } from 'rxjs';
import { DateRangeQuerySearchFilter } from '../../models/date-range-query-search-filter.model';

@Component({
  selector: 'xyz-date-range-query-search-filter',
  templateUrl: './date-range-query-search-filter.component.html',
  styleUrls: ['./date-range-query-search-filter.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DateRangeQuerySearchFilterComponent implements OnInit, OnDestroy {
  private _subscriptionSubject: Subject<any> = new Subject<any>();

  @Input()
  public set filter(filter: DateRangeQuerySearchFilter | null) {
    if (filter) {
      this.form.patchValue({ ...filter }, { emitEvent: false });
    }
  }

  @Input()
  public debounceTime: number = 500;

  @Input()
  public startDateLabel: string = 'Start Date';

  @Input()
  public endDateLabel: string = 'End Date';

  @Input()
  public dateFormat: string = 'MM/dd/yyyy';

  @Output()
  public onSearchChanges: EventEmitter<DateRangeQuerySearchFilter> = new EventEmitter<DateRangeQuerySearchFilter>();

  public form: FormGroup;

  constructor() {
    this.form = new FormGroup({
      query: new FormControl(''),
      startDate: new FormControl(null),
      endDate: new FormControl(null)
    });
  }

  ngOnInit(): void {
    this._listenForSearchQueryChanges();
  }

  public onSearch(filter: DateRangeQuerySearchFilter): void {
    this.onSearchChanges.emit(filter);
  }

  public onDateRangeChange(dates: any): void {
    console.log("dates are ", dates);
  }

  private _listenForSearchQueryChanges(): void {
    this.form.valueChanges
      .pipe(
        takeUntil(this._subscriptionSubject),
        distinctUntilChanged(),
        debounceTime(this.debounceTime)
      )
      .subscribe((filter: DateRangeQuerySearchFilter) => this.onSearchChanges.emit(filter));
  }

  ngOnDestroy(): void {
    this._subscriptionSubject.next(null);
    this._subscriptionSubject.complete();
  }
}
