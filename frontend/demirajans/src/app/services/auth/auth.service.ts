import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { AccessToken, LoginDto } from './models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = 'Auth';

  constructor(private proxyService: ProxyService) {}

  login(loginDto: LoginDto): Observable<AccessToken> {
    return this.proxyService
      .post<AccessToken>(this.baseUrl + '/login', loginDto, {
        withCredentials: true,
      })
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
