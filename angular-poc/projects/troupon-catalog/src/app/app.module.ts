import { HttpClientModule } from '@angular/common/http';
import { Injector, NgModule } from '@angular/core';
import { createCustomElement } from '@angular/elements';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from 'projects/troupon-web/src/app/shared/material/material.module';
import { SharedModule } from 'projects/troupon-web/src/app/shared/shared.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    HttpClientModule,
    SharedModule,
  ],
  providers: [],
})
export class AppModule {
  constructor(private injector: Injector) { }
  ngDoBootstrap() {
    const el = createCustomElement(AppComponent, { injector: this.injector });
    customElements.define('troupon-catalog', el);
  }
}
