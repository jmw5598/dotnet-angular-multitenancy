import { NavigationLink, ModulePermissionType } from '@xyz/office/modules/core/models';

export const defaultNavigationMenu: NavigationLink[] = [
  {
    label: 'Dashboard',
    routerLink: '/dashboard',
    icon: 'dashboard',
    requireModulePermissionType: ModulePermissionType.Dashboard
  },
  {
    label: 'Service',
    routerLink: '/service',
    icon: 'calendar',
    requireModulePermissionType: ModulePermissionType.Service
  },
  {
    label: 'Inventory',
    routerLink: '/inventory',
    icon: 'tags',
    requireModulePermissionType: ModulePermissionType.Inventory
  },
  {
    label: 'Settings',
    icon: 'setting',
    requireModulePermissionType: ModulePermissionType.Settings,
    children: [
      {
        label: 'User Accounts',
        routerLink: '/settings/user-accounts',
        icon: 'user',
        requireModulePermissionType: ModulePermissionType.UserAccounts
      }
    ]
  }
  // @Note: Below is an example of submenu link
  // {
  //   label: 'Settings',
  //   icon: 'setting',
  //   children: [
  //     {
  //       label: 'Settings Sub',
  //       routerLink: '/settings/sub',
  //     }
  //   ]
  // }
];
