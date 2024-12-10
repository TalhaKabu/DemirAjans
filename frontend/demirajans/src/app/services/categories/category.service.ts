import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ProxyService } from '../proxy/proxy.service';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private baseUrl = 'Category';

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

  getList(): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/list')
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
