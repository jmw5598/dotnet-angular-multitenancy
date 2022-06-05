import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, of } from 'rxjs';

import { EnvironmentService } from '../../core/services';

@Injectable({
  providedIn: 'root'
})
export class IsNotLoadedFromSubdomainGuard implements CanActivate {
  constructor(
    private _environmentService: EnvironmentService,
    private _router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const subdomain: string = this._environmentService.getSubdomain(); 

    if (!subdomain || !subdomain?.trim()?.length) {
      this._router.navigateByUrl("/auth/company-search");
    }

    return of(true);
  }
}
