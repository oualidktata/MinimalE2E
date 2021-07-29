import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Deal } from 'projects/troupon-web/src/app/models/deal.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
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
