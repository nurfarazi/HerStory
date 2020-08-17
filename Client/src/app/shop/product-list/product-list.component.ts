import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../../shared/models/product';
import { IType } from '../../shared/models/productType';
import { ShopParams } from '../../shared/models/shopParams';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  products: IProduct[];

  types: IType[];
  shopParams: ShopParams;
  totalCount: number;

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private shopService: ShopService) {
    this.shopParams = this.shopService.getShopParams();
  }

  ngOnInit(): void {
    this.getTypes();
    this.getProducts();
  }

  getProducts(): void {
    this.shopService.getProducts().subscribe(response => {
      this.products = response.data;
      console.log(this.products);
      this.totalCount = response.count;
    }, error => console.log(error));
  }

  getTypes(): void {
    this.shopService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    }, error => console.log(error));
  }

  onTypeSelected(productTypeId: number): void {
    const params = this.shopService.getShopParams();
    params.productTypeId = productTypeId;
    params.pageNumber = 1;
    this.shopService.setShopParams(params);
    this.getProducts();
  }

  onSortSelected(sort: string): void {
    const params = this.shopService.getShopParams();
    params.sort = sort;
    this.shopService.setShopParams(params);
    this.getProducts();
  }

  onSearch(): void {
    const params = this.shopService.getShopParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.shopService.setShopParams(params);
    this.getProducts();
  }

  onReset(): void {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.shopService.setShopParams(this.shopParams);
    this.getProducts();
  }

  onPageChanged(event: any): void {
    const params = this.shopService.getShopParams();
    if (params.pageNumber !== event.page) {
      params.pageNumber = event.page;
      this.shopService.setShopParams(params);
      this.getProducts();
    }
  }
}
