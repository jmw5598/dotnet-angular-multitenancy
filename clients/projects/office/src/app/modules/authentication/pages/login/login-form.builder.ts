import { FormBuilder, FormGroup, Validators } from "@angular/forms";

export const buildLoginForm: Function = (formBuilder: FormBuilder): FormGroup => {
  return formBuilder.group({
    username: ['', [Validators.required]],
    password: ['', [Validators.required]],
    rememberMe: [false, [Validators.required]]
  });
};
