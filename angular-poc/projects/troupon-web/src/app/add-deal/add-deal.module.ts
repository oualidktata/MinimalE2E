import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDealComponent } from './add-deal.component';
import { AddDealRoutingModule } from './add-deal-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    AddDealComponent
  ],
  imports: [
    CommonModule,
    AddDealRoutingModule,
    SharedModule,
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA]
})
export class AddDealModule { }
