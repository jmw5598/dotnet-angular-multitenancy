// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  api: {
    protocol: 'http',
    subdomain: '',
    domain: 'localhost',
    port: '7133',
    apiSlug: 'api',
    authSlug: 'api/auth'
  },
  client: {
    protocol: 'http',
    subdomain: '',
    domain: 'localhost',
    port: '4200'
  },
  stripe: {
    publishableKey: 'pk_test_51LBoQtL7sSBhqolv5kxNEVt2eWXOVCYnE9BGN4T2ZVZA65ZuYWh1OmkyW059QSCpvHA9OOzhO1hEFqFXsWuoexMS00BlaeNFkv'
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
