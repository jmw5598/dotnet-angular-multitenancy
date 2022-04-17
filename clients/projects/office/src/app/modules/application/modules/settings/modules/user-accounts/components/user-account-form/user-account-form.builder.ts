import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UserPermission } from "@xyz/office/modules/core/entities";
import { UserPermissionGroup } from "@xyz/office/modules/core/models";
import { MatchValidators, ValidationPatterns } from "@xyz/office/modules/core/validators";

export const buildUserAccountForm = (formBuilder: FormBuilder, userPermissionGroups: UserPermissionGroup[]) => formBuilder.group({
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
  userPermissionGroups: buildUserPermissionGroupsFormArray(formBuilder, userPermissionGroups)
});

export const buildUserPermissionGroupsFormArray = 
  (formBuilder: FormBuilder, userPermissionGroups: UserPermissionGroup[]): FormArray => formBuilder.array([
    ...userPermissionGroups.map(group => formBuilder.group({
      hasAccess: [group.hasAccess],
      userPermission: formBuilder.group({
        ...buildUserPermissionFormGroup(formBuilder, group.userPermission).controls,
        childUserPermissions: formBuilder.array([
          ...group?.userPermission
            ?.childUserPermissions
            ?.map(childUserPermission => buildUserPermissionFormGroup(formBuilder, childUserPermission)) || []
        ])
      })
    }))
  ]);

export const buildUserPermissionFormGroup = 
  (formBuilder: FormBuilder, userPermission: UserPermission): FormGroup => formBuilder.group({
    canCreate: [userPermission.canCreate],
    canRead: [userPermission.canRead],
    canUpdate: [userPermission.canUpdate],
    canDelete: [userPermission.canDelete],
    permission: formBuilder.group({
      id: [userPermission?.permission?.id],
      name: [userPermission?.permission?.name]
    }),
  });

