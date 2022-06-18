import { Injectable } from "@angular/core";
import { AbstractControl, AsyncValidatorFn } from "@angular/forms";
import { catchError, debounceTime, filter, map, Observable, of, switchMap, take } from "rxjs";
import { ValidationResult } from "../models";
import { CompaniesService } from "@xyz/office/modules/core/services/multitenancy";

@Injectable({
  providedIn: 'root'
})
export class CompanyNameValidators  {
  constructor(
    private _companiesService: CompaniesService 
  ) { }

  public validateCompanyName(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any} | null> => {
      return control.valueChanges.pipe(
        debounceTime(500),
        filter(value => value.trim().length > 0),
        take(1),
        switchMap(() => this._companiesService.doesCompanyExist(control.value.trim().toLowerCase())
          .pipe(
            map((result: ValidationResult) => result.isValid ? null : { companyExists: true }),
            catchError(error => of(null))
          )
        )
      );
    }
  }
}