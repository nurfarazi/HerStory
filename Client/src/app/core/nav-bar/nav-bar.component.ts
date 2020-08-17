import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/shared/models/user';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from '../../basket/basket.service';
import { IBasket } from '../../shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  currentUser$: Observable<IUser>;
  basket$: Observable<IBasket>;

  constructor(private accountService: AccountService,
              private basketService: BasketService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.basket$ = this.basketService.basket$;
    this.loadBasket();
  }

  loadBasket(): void {
    this.basketService.getBasket().subscribe(() => {
      console.log('initialised basket');
    }, error => console.log(error));
  }

  logout(): void {
    this.accountService.signOut();
  }

}
