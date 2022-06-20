import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { catchError, debounceTime, delay, filter, map, Observable, of, switchMap, take, tap } from 'rxjs';
import { ValidationResult } from '../models';
import { CompaniesService } from '@xyz/office/modules/core/services/multitenancy';

@Injectable({
  providedIn: 'root'
})
export class CompanyNameValidators  {
  constructor(
    private _companiesService: CompaniesService 
  ) { }

  public validateCompanyName(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any} | null> => {
      return this._companiesService.doesCompanyExist(control?.value?.trim()?.toLowerCase())
        .pipe(
          take(1),
          map((result: ValidationResult) => result.isValid ? null : { companyExists: true }),
          catchError(error => of(null))
        );
    }
  }
}