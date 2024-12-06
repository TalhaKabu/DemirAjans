import { Injectable } from '@angular/core';
import { ProxyService } from '../proxy/proxy.service';
import { ActivationCreateDto, VerifyActivationDto } from './models';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ActivationService {
  private baseUrl = 'Activation';

  constructor(private proxyService: ProxyService) {}

  sendActivationCode(createDto: ActivationCreateDto): Observable<any> {
    return this.proxyService
      .post<any>(this.baseUrl + '/send-activation-code', createDto)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }

  verifyActivationCode(verifyDto: VerifyActivationDto): Observable<any> {
    return this.proxyService
      .post<any>(this.baseUrl + '/verify-activation-code', verifyDto)
      .pipe(
        catchError((error) => {
          return throwError(() => error);
        })
      );
  }
}
