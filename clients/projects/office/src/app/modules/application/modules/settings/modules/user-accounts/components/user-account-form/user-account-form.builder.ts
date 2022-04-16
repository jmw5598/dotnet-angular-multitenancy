import { FormBuilder, Validators } from "@angular/forms";
import { MatchValidators, ValidationPatterns } from "@xyz/office/modules/core/validators";

export const buildUserAccountForm = (formBuilder: FormBuilder) => formBuilder.group({
  user: formBuilder.group({
    userName: ['', [Validators.required, Validators.email]],
    password: ['', [
      Validators.required,
      Validators.minLength(6),
      Validators.pattern(ValidationPatterns.password)
    ]],
    confirmPassword: ['', [
      Validators.required,
      Validators.minLength(6),
      Validators.pattern(ValidationPatterns.password)
    ]]
  }, { validators: [MatchValidators.mustMatch('password', 'confirmPassword')]}),
  profile: formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]]
  }),
  permissions: formBuilder.group({})
});