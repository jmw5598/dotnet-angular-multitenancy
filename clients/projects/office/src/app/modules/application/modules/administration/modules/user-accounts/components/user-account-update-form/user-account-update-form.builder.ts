import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { UserModulePermission } from '@xyz/office/modules/core/entities/tenants';

export const buildUserAccountUpdateForm = (
    formBuilder: FormBuilder,
    userModulePermissions: UserModulePermission[]
  ) => formBuilder.group({
    user: formBuilder.group({
      id: [null, [Validators.required]],
      userName: [{ value: null, disabled: true }]
    }),
    profile: formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]]
    }),
    userModulePermissions: builderUserModulePermissionsFormArray(formBuilder, userModulePermissions)
  });

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
