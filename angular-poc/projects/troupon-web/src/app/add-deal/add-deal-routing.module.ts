import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OktaAuthGuard } from '@okta/okta-angular';
import { AddDealComponent } from './add-deal.component';

const routes: Routes = [
  {
    path: '',
    component: AddDealComponent,
    canActivate: [OktaAuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddDealRoutingModule { }
