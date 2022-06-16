import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { ClientSettings } from '@xyz/office/modules/core/services';
import { debounceTime, Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'xyz-registration-company-form',
  templateUrl: './registration-company-form.component.html',
  styleUrls: ['./registration-company-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationCompanyFormComponent implements OnInit, OnDestroy {
  private _destroy$: Subject<any> = new Subject<any>();
  public formGroup: FormGroup;

  @Input()
  public clientSettings: ClientSettings | null = null;

  constructor(private _controlContainer: ControlContainer) {
    this.formGroup = (this._controlContainer.control as FormGroup).get('company') as FormGroup;
  }

  ngOnInit(): void {
    this._listenForCompanyFieldChanges();
    this._listenForDomainFieldChanges();
  }

  public _listenForCompanyFieldChanges(): void {
    this.formGroup?.get('name')?.valueChanges
      .pipe(
        takeUntil(this._destroy$),
        debounceTime(500)
      )
      .subscribe(value => {
        const currentSubdomainValue: string = this.formGroup.get('subdomain')?.value?.trim() || '';
        this._patchThroughValidSubdomain(value);
      })
  }

  public _listenForDomainFieldChanges(): void {
    this.formGroup?.get('name')?.valueChanges
      .pipe(
        takeUntil(this._destroy$),
        debounceTime(500)
      )
      .subscribe(value => this._patchThroughValidSubdomain)
  }

  private _patchThroughValidSubdomain(value: string): void {
    const now: Date = new Date();
    const suffix: string = `${now.getHours().toString().padStart(2, '0')}${now.getMinutes().toString().padStart(2, '0')}${now.getMilliseconds().toString().padStart(2, '0')}`;
    const subdomain: string = value.trim().toLowerCase().replace(/[^0-9A-Za-z]/g, '');
    this.formGroup?.get('subdomain')?.patchValue(`${subdomain}${suffix}`);
  }

  ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
