import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';
import { catchError, switchMap, tap } from 'rxjs/operators';

const authorizationHeader = 'Authorization';
const bearerPrefix = 'Bearer';

@Injectable({
  providedIn: 'root',
})
export class OktaInterceptor implements HttpInterceptor {

  constructor(
    private readonly oktaAuth: OktaAuthService,
  ) {

  }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    let currentToken: string | undefined;
    currentToken = this.oktaAuth.getAccessToken();

    if (currentToken == undefined) return next.handle(req);

    return this.executeRequest(req, next, currentToken);
  }

  private executeRequest = (req: HttpRequest<any>, next: HttpHandler, currentToken: string) => {
    const requestWithJwt = currentToken !== undefined
      ? req.clone({
        setHeaders: {
          [authorizationHeader]: `${bearerPrefix} ${currentToken}`,
        },
      })
      : req;

    return next.handle(requestWithJwt);
  }
}
