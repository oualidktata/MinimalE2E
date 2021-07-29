import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    SharedModule,
    HomeRoutingModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class HomeModule { }
