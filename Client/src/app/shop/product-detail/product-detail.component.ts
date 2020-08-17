import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from '../../basket/basket.service';
import { IProduct } from '../../shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  quantity = 1;
  productId: string;

  constructor(private shopService: ShopService,
              private activateRoute: ActivatedRoute,
              private basketService: BasketService) {
    this.productId = this.activateRoute.snapshot.paramMap.get('id');
    console.log(this.productId);
  }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    this.shopService.getProduct(this.productId).subscribe(product => {
      this.product = product;
    }, error => console.log(error));
  }

  incrementQuantity(): void {
    this.quantity++;
  }

  decrementQuantity(): void {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  addProductToBasket(): void {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }
}
