import { NavigationLink } from '@xyz/office/modules/core/models';

export const defaultNavigationMenu: NavigationLink[] = [
  {
    label: 'Dashboard',
    routerLink: '/dashboard',
    icon: 'dashboard',
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
    routerLink: 'setting',
    icon: 'setting'
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
