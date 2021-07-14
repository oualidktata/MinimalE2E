import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbar } from '@angular/material/toolbar'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OktaAuthModule, OKTA_CONFIG } from '@okta/okta-angular';
import { SharedModule } from './shared/shared.module';
import { AngularMaterialModule } from './shared/material/material.module';
import { interceptors } from './interceptors/interceptors';
import { HttpClientModule } from '@angular/common/http';

const config = {
  clientId: '0oaa80ln6ceY5H5ey357',
  issuer: 'https://dev-193568.okta.com/oauth2/default',
  redirectUri: 'http://localhost:4200/login/callback',
  postLogoutRedirectUri: 'http://localhost:4200/logout',
  scopes: ['openid', 'profile', 'email'],
  pkce: true
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    OktaAuthModule,
    AngularMaterialModule,
    HttpClientModule,
    SharedModule,
  ],
  providers: [
    { provide: OKTA_CONFIG, useValue: config },


    ...interceptors,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
