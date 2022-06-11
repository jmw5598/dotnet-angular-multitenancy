import { NavigationLink, ModulePermissionNames, PermissionNames } from '@xyz/office/modules/core/models';

export const defaultNavigationMenu: NavigationLink[] = [
  {
    label: 'Dashboard',
    routerLink: '/dashboard',
    icon: '/dashboard',
    requiredModulePermissionName: ModulePermissionNames.DASHBOARD_MODULE,
    children: [
      {
        label: 'Overview',
        routerLink: '/dashboard/overview',
        requiredPermissionName: PermissionNames.DASHBOARD_OVERVIEW
      },
    ]
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
    label: 'Administration',
    icon: 'setting',
    requiredModulePermissionName: ModulePermissionNames.ADMINISTRATION_MODULE,
    children: [
      {
        label: 'Account Details',
        routerLink: '/admin/account-details',
        requiredPermissionName: PermissionNames.ACCOUNT_DETAILS
      },
      {
        label: 'User Accounts',
        routerLink: '/admin/user-accounts',
        requiredPermissionName: PermissionNames.USER_ACCOUNTS
      },
      {
        label: 'Settings',
        routerLink: '/admin/settings',
        requiredPermissionName: PermissionNames.SETTINGS
      },
    ]
  },
  {
    label: 'Security',
    icon: 'lock',
    requiredModulePermissionName: ModulePermissionNames.SECURITY_MODULE,
    children: [
      {
        label: 'General',
        routerLink: '/security/general',
        requiredPermissionName: PermissionNames.SECURITY_GENERAL
      },
      {
        label: 'Permissions',
        routerLink: '/security/permissions',
        requiredPermissionName: PermissionNames.SECURITY_PERMISSIONS
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
