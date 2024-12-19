import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = 'User';

  constructor(private proxyService: ProxyService) {}

  get(id: number): Observable<any> {
    return this.proxyService
      .get<any>(this.baseUrl + '/get', { withCredentials: true })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
