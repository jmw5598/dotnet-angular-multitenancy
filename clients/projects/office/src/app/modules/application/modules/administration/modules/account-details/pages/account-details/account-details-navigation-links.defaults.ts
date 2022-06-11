import { ModulePermissionNames, TabNavigationLink } from "@xyz/office/modules/core/models";

export const defaultAccountDetailsNavigationLinks: TabNavigationLink[] = [
  {
    label: 'Account',
    routerLink: './info',
    queryParams: { tab: 'info' },
    queryParamsHandling: 'merge'
    // requiredModulePermissionName: ModulePermissionNames.DASHBOARD_MODULE,
  },
  {
    label: 'Billing',
    routerLink: './billing',
    queryParams: { tab: 'billing' },
    queryParamsHandling: 'merge'
    // requiredModulePermissionName: ModulePermissionNames.DASHBOARD_MODULE,
  },
];
