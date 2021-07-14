import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';
import { OktaAuthService } from '@okta/okta-angular';
import { from, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate, CanActivateChild {
  constructor(
    private readonly router: Router,
    private readonly oktaAuth: OktaAuthService
  ) {

  }

  canActivate = (_: ActivatedRouteSnapshot, state: RouterStateSnapshot) => this.doCheckAuth(state);
  canActivateChild = (_: ActivatedRouteSnapshot, state: RouterStateSnapshot) => this.doCheckAuth(state);

  private doCheckAuth = (state: RouterStateSnapshot) => {
    return from(this.oktaAuth.isAuthenticated())
        .pipe(
          map(isAuthenticated => {
            if (!isAuthenticated) {
              this.router.navigateByUrl('/login');
              return false;
            }
            return true;
          }),
          catchError(() => {
            this.router.navigateByUrl('/login');
            return of(false);
          }),
        );
  }
}
