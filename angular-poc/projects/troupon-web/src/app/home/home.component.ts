import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Deal } from '../models/deal.model';

@Component({
  selector: 'troupon-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent {

  title = 'troupon-web';

}
