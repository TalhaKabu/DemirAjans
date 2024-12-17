import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private baseUrl = 'Product';

  constructor(private proxyService: ProxyService) {}

  get(id: number): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/get', {
        Id: id,
      })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  getListByAppearInFront(appearInFront: boolean): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/list-by-appear-in-front', {
        appearInFront: appearInFront,
      })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  getListByCategoryIdAndAppearInFront(
    categoryId: number,
    appearInFront: boolean
  ): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/list-by-category-id-appear-in-front', {
        categoryId: categoryId,
        appearInFront: appearInFront,
      })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  getListByCategoryIdAndSubCategoryId(
    categoryId: number,
    subCategoryId: number
  ): Observable<any> {
    return this.proxyService
      .get<any>(
        this.baseUrl + '/list-by-category-id-sub-category-id',
        subCategoryId === 0
          ? {
              categoryId: categoryId,
            }
          : {
              categoryId: categoryId,
              subCategoryId: subCategoryId,
            }
      )
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
