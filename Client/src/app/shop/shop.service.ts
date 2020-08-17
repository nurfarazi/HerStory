import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { IPagination, Pagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = environment.apiUrl;
  products: IProduct[] = [];
  types: IType[] = [];

  pagination = new Pagination();
  shopParams = new ShopParams();

  constructor(private http: HttpClient) {
  }

  getProducts(): Observable<any> {

    let params = new HttpParams();

    if (this.shopParams.productTypeId !== 0) {
      params = params.append('productTypeId', this.shopParams.productTypeId.toString());
    }

    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }

    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber.toString());
    params = params.append('pageSize', this.shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'product', { observe: 'response', params })
      .pipe(
        map(response => {
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getProduct(id: string): Observable<IProduct> {
    return this.http.get<IProduct>(this.baseUrl + 'product/' + id);
  }

  getTypes(): Observable<IType[]> {
    return this.http.get<IType[]>(this.baseUrl + 'productType').pipe(
      map(response => {
        // @ts-ignore
        this.types = response.data;
        // @ts-ignore
        return response.data;
      })
    );
  }

  getShopParams(): ShopParams {
    return this.shopParams;
  }

  setShopParams(params: ShopParams): void {
    this.shopParams = params;
  }

}
