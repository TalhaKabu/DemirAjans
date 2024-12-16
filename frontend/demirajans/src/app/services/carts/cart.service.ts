import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { catchError, Observable, throwError } from 'rxjs';
import { CartCreateDto } from './models';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private baseUrl = 'Cart';

  constructor(private proxyService: ProxyService) {}

  getListByUserId(userId: number): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/get-list-by-user-id', {
        userId: userId,
      })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  insert(create: CartCreateDto): Observable<any> {
    return this.proxyService.post<any>(this.baseUrl + '/insert', create).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }
}
