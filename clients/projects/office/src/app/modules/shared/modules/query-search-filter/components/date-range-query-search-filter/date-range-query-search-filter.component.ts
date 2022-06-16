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
      this.form.patchValue({ 
        query: filter?.query || null,
        startDate: filter?.startDate ? new Date(Date.parse(filter.startDate || '')) : null,
        endDate: filter?.endDate ? new Date(Date.parse(filter?.endDate || '')) : null
      }, { emitEvent: false });
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

  public onSearch(filterForm: any): void {
    const filter: DateRangeQuerySearchFilter = this._formValueToSearchFilter(filterForm);
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
      .subscribe((filterForm: any) => {
        const filter: DateRangeQuerySearchFilter = this._formValueToSearchFilter(filterForm);
        this.onSearchChanges.emit(filter)
      });
  }

  private _formValueToSearchFilter(formValue: any): DateRangeQuerySearchFilter {
    return {
      query: formValue.query,
      startDate: formValue.startDate ? (formValue.startDate as Date).toISOString() : '',
      endDate: formValue.endDate ? (formValue.endDate as Date).toISOString() : ''
    } as DateRangeQuerySearchFilter;
  }

  ngOnDestroy(): void {
    this._subscriptionSubject.next(null);
    this._subscriptionSubject.complete();
  }
}
