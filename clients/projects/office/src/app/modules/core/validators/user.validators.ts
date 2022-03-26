import { Injectable } from "@angular/core";
import { AbstractControl, AsyncValidatorFn } from "@angular/forms";
import { catchError, debounceTime, filter, map, Observable, switchMap, take } from "rxjs";
import { AuthenticationService } from "../../authentication/services/authentication.service";

@Injectable({
  providedIn: 'root'
})
export class UserValidators  {
  constructor(private _accountsService: AuthenticationService) {}

  validateEmail(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any}> => {
      return control.valueChanges.pipe(
        debounceTime(500),
        filter(value => value.trim().length > 0),
        take(1),
        switchMap(() => this._accountsService.validateEmail(control.value)
          .pipe(
            map((result: ValidatorResult) => 
              result.isValid ? null : { emailExists: true }),
            catchError(error => of(null))
          )
        )
      );
    }
  }

  validateUsername(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any}> => {
      return control.valueChanges.pipe(
        debounceTime(500),
        filter(value => value.trim().length > 0),
        take(1),
        switchMap(() => this._accountsService.validateUsername(control.value)
          .pipe(
            map((result: ValidatorResult) => 
              result.isValid ? null : { usernameExists: true }),
            catchError(error => of(null))
          )
        )
      );
    }
  }
}