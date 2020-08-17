import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { IBasket, IBasketItem } from '../shared/models/basket';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;

  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  private basketTotalSource = new BehaviorSubject<number>(0);
  basketTotal$ = this.basketTotalSource.asObservable();

  shipping = 0;
  basketId = 1;

  constructor(private http: HttpClient) {
  }

  getCurrentBasketValue(): IBasket {
    return this.basketSource.value;
  }

  getBasket(id = 1): Observable<any> {
    return this.http.get(this.baseUrl + 'basket/' + id)
      .pipe(
        tap(basket => {
          if (basket === null) {
            this.createBasket();
          }
        }),
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.shipping = basket.shippingPrice;
          this.calculateTotals();
        })
      );
  }

  async addItemToBasket(item: IProduct, quantity = 1): Promise<void> {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    let basket = this.getCurrentBasketValue();
    if (basket === null) {
      basket = await this.createBasket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasketItem(itemToAdd);
  }

  setBasketItem(item: IBasketItem): Subscription {
    return this.http.post(this.baseUrl + 'basket/basketItem/' + this.basketId, item)
      .subscribe((response: IBasket) => {
        this.calculateTotals();
      }, error => console.log(error));
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.productId === itemToAdd.productId);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  private async createBasket(): Promise<IBasket> {
    const body = {
      clientSecret: 'email@gmail.com'
    };
    await this.http.post(this.baseUrl + 'basket', body);
    return await this.getBasket().toPromise();
  }

  private calculateTotals(): void {
    const basket = this.getCurrentBasketValue();
    const total = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    this.basketTotalSource.next(total);
  }

  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      productName: item.title,
      productId: item.id,
      price: item.price,
      quantity
    };
  }

  deleteBasket(basket: IBasket): void {

  }
}
