import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UserModulePermission } from "@xyz/office/modules/core/entities";
import { MatchValidators, UserValidators, ValidationPatterns } from "@xyz/office/modules/core/validators";

export const buildUserAccountForm = (
    formBuilder: FormBuilder, 
    userValidators: UserValidators, 
    userModulePermissions: UserModulePermission[]
  ) => formBuilder.group({
    user: formBuilder.group({
      userName: ['', [
        Validators.required, 
        Validators.email
      ], [userValidators.validateEmail()]],
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
    userModulePermissions: builderUserModulePermissionsFormArray(formBuilder, userModulePermissions)
  });

/*
  @TODO
  Will also need function to patch through users current permissions to this form array.
*/

export const builderUserModulePermissionsFormArray = 
  (formBuilder: FormBuilder, userModulePermissions: UserModulePermission[]) : FormArray => formBuilder.array([
    ...userModulePermissions?.map(m => formBuilder.group({
      id: [m.id],
      hasAccess: [m.hasAccess],
      canCreateAll: [false],
      canReadAll: [false],
      canUpdateAll: [false],
      canDeleteAll: [false],
      modulePermissionId: [m.modulePermissionId],
      modulePermission: formBuilder.group({
        id: [m?.modulePermission?.id],
        name: [m?.modulePermission?.name]
      }),
      userPermissions: formBuilder.array([
        ...m?.userPermissions?.map(permission => {
          return formBuilder.group({
            canCreate: [permission.canCreate],
            canRead: [permission.canRead],
            canUpdate: [permission.canUpdate],
            canDelete: [permission.canDelete],
            permission: formBuilder.group({
              id: [permission?.permission?.id],
              name: [permission?.permission?.name]
            })
          })
        }) || []
      ])
    })) || []
  ]);
