import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Deal } from 'projects/troupon-web/src/app/models/deal.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  formGroup: FormGroup | undefined;
  deal: Deal | undefined;

  @Output()
  dealAdded = new EventEmitter();

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly httpClient: HttpClient,
  ) { }

  ngOnInit(): void {
    this.deal = {
      name: '',
      description: '',
      address: '',
      currentPrice: 0,
      originalPrice: 0,
      image: '',
    };
    this.setupForm();
  }

  setupForm = () => {
    if (!this.deal) return;
    this.formGroup = this.formBuilder.group({
      name: [this.deal.name, Validators.required],
      description: [this.deal.description, Validators.required],
      address: [this.deal.address, Validators.required],
      currentPrice: [this.deal.currentPrice, Validators.required],
      originalPrice: [this.deal.originalPrice, Validators.required],
      image: [this.deal.image, Validators.required],
    });
  }

  addDeal = () => {
    if (!this.deal || !this.formGroup || !this.formGroup.valid) return;
    const nameForm = this.formGroup.get('name');
    const descriptionForm = this.formGroup.get('description');
    const addressForm = this.formGroup.get('address');
    const currentPriceForm = this.formGroup.get('currentPrice');
    const originalPriceForm = this.formGroup.get('originalPrice');
    const imageForm = this.formGroup.get('image');

    if (!nameForm || !descriptionForm || !addressForm || !currentPriceForm || !originalPriceForm || !imageForm) return;

    this.deal.name = nameForm.value;
    this.deal.description = descriptionForm.value;
    this.deal.address = addressForm.value;
    this.deal.currentPrice = currentPriceForm.value;
    this.deal.originalPrice = originalPriceForm.value;
    this.deal.image = imageForm.value;

    this.httpClient.post('https://localhost:44355/Catalog/Deals', this.deal)
    .subscribe(() => {
      this.dealAdded.emit();
    });
  }
}
