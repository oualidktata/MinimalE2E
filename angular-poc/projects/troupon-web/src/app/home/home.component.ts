import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Deal } from '../models/deal.model';

@Component({
  selector: 'troupon-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  title = 'troupon-web';
  deals : Deal[] = [];

  constructor(
    private readonly http: HttpClient,
  ) { }

  ngOnInit(): void {
    this.http.get<Deal[]>('https://localhost:44355/Catalog/Deals')
    .subscribe(res => {
      this.deals = res;
    })
  }


  calculateRebate = (deal: Deal) => {
    return Math.floor(100 * (deal.originalPrice - deal.currentPrice) / deal.originalPrice)
  }
}
