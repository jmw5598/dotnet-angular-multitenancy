import { NavigationLink, ModulePermissionNames, PermissionNames } from '@xyz/office/modules/core/models';

export const defaultNavigationMenu: NavigationLink[] = [
  {
    label: 'Dashboard',
    routerLink: '/dashboard',
    icon: 'dashboard',
    requiredModulePermissionName: ModulePermissionNames.DASHBOARD_MODULE
  },
  {
    label: 'Service',
    routerLink: '/service',
    icon: 'calendar',
    requiredModulePermissionName: ModulePermissionNames.SERVICE_MODULE
  },
  {
    label: 'Inventory',
    routerLink: '/inventory',
    icon: 'tags',
    requiredModulePermissionName: ModulePermissionNames.INVENTORY_MODULE
  },
  {
    label: 'Settings',
    icon: 'setting',
    requiredModulePermissionName: ModulePermissionNames.SETTINGS_MODULE,
    children: [
      {
        label: 'User Accounts',
        routerLink: '/settings/user-accounts',
        icon: 'user',
        requiredPermissionName: PermissionNames.USER_ACCOUNTS_MODULE
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
