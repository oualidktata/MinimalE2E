import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'troupon-add-deal',
  templateUrl: './add-deal.component.html',
  styleUrls: ['./add-deal.component.less']
})
export class AddDealComponent {

  constructor(
    private readonly router: Router,
  ) {

  }

  redirect = () => {
    this.router.navigateByUrl('home');
  }

}
