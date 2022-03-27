import { Injectable } from "@angular/core";
import { AbstractControl, AsyncValidatorFn } from "@angular/forms";
import { catchError, debounceTime, filter, map, Observable, of, switchMap, take } from "rxjs";
import { ValidatorResult } from "../models";
import { UsersService } from "../services/users.service";

@Injectable({
  providedIn: 'root'
})
export class UserValidators  {
  constructor(
    private _usersService: UsersService
  ) { }

  public validateEmail(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any} | null> => {
      return control.valueChanges.pipe(
        debounceTime(500),
        filter(value => value.trim().length > 0),
        take(1),
        switchMap(() => this._usersService.verifyEmail(control.value)
          .pipe(
            map((result: ValidatorResult) => result.isValid ? of(null) : of({ emailExists: true })),
            catchError(error => of(null))
          )
        )
      );
    }
  }

  public validateUsername(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{[key: string]: any} | null> => {
      return control.valueChanges.pipe(
        debounceTime(500),
        filter(value => value.trim().length > 0),
        take(1),
        switchMap(() => this._usersService.verifyUserName(control.value)
          .pipe(
            map((result: ValidatorResult) => result.isValid ? of(null) : of({ userNameExists: true })),
            catchError(error => of(null))
          )
        )
      );
    }
  }
}