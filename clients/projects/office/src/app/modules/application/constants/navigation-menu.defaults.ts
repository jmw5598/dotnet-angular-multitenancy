import { NavigationLink, ModulePermissionType } from '@xyz/office/modules/core/models';

export const defaultNavigationMenu: NavigationLink[] = [
  {
    label: 'Dashboard',
    routerLink: '/dashboard',
    icon: 'dashboard'
  },
  {
    label: 'Service',
    routerLink: '/service',
    icon: 'calendar'
  },
  {
    label: 'Inventory',
    routerLink: '/inventory',
    icon: 'tags'
  },
  {
    label: 'Settings',
    icon: 'setting',
    modulePermissionType: ModulePermissionType.Settings,
    children: [
      {
        label: 'User Accounts',
        routerLink: '/settings/user-accounts',
        icon: 'user',
        modulePermissionType: ModulePermissionType.UserAccounts
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
