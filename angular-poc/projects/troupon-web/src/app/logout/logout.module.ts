import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoutComponent } from './logout.component';
import { SharedModule } from '../shared/shared.module';
import { LogoutRoutingModule } from './logout-routing.module';



@NgModule({
  declarations: [
    LogoutComponent
  ],
  imports: [
    SharedModule,
    LogoutRoutingModule,
  ]
})
export class LogoutModule { }
