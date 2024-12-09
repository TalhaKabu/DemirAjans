import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'Product';

  constructor(private proxyService: ProxyService) {}

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
}
