import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../account/account.service';
import { BasketService } from '../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../shared/models/basket';
import { CheckoutService } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  basketTotals$: Observable<number>;
  checkoutForm: FormGroup;

  constructor(private fb: FormBuilder,
              private accountService: AccountService,
              private basketService: BasketService,
              private checkoutService: CheckoutService,
              private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.createCheckoutForm();
    this.basketTotals$ = this.basketService.basketTotal$;
  }

  createCheckoutForm(): void {
    this.checkoutForm = this.fb.group({
      addressForm: this.fb.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        street: [null, Validators.required],
        city: [null, Validators.required],
        state: [null, Validators.required],
        zipcode: [null, Validators.required],
      }),
      deliveryForm: this.fb.group({
        deliveryMethod: [null, Validators.required]
      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required]
      })
    });
  }

  async submitOrder(): Promise<void> {
    const basket = this.basketService.getCurrentBasketValue();
    try {
      await this.createOrder(basket);
      this.basketService.deleteBasket(basket);
      this.toastr.success('Order Complete');
    } catch (error) {
      console.log(error);
    }
  }


  createOrder(basket: IBasket): Promise<any> {
    const orderToCreate = this.getOrderToCreate(basket);
    return this.checkoutService.creatOrder(orderToCreate).toPromise();
  }

  private getOrderToCreate(basket: IBasket): { basketId: string; shipToAddress: any; deliveryMethodId: number } {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value
    };
  }
}
