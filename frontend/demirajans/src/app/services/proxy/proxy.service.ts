import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SpinningBarService } from '../../helpers/services/spinning-bar.service';

@Injectable({
  providedIn: 'root',
})
export class ProxyService {
  private baseUrl = environment.apiUrl;
  private token = localStorage.getItem('token');

  constructor(private http: HttpClient, private sp: SpinningBarService) {}

  get<T>(
    endpoint: string,
    params: any = null,
    headers: any = null
  ): Observable<T> {
    this.sp.loading(true);
    return this.http
      .get<T>(`${this.baseUrl}/${endpoint}`, {
        headers: {
          Authorization: `Bearer ${this.token}`,
          'Content-Type': 'application/json',
        },
        params: params,
      })
      .pipe(
        tap((_) => setTimeout( () => { this.sp.loading(false) }, 3000 )),
        catchError((error) => {
          console.error('Error:', error);
          return throwError(() => error);
        })
      );
  }

  post<T>(
    endpoint: string,
    body: any = null,
    params: any = null
  ): Observable<T> {
    this.sp.loading(true);
    return this.http
      .post<T>(`${this.baseUrl}/${endpoint}`, body, {
        headers: {
          Authorization: `Bearer ${this.token}`,
          'Content-Type': 'application/json',
        },
        params: params,
      })
      .pipe(
        tap((_) => this.sp.loading(false)),
        catchError((error) => {
          console.error('Error:', error);
          return throwError(() => error);
        })
      );
  }

  put<T>(endpoint: string, data: any): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${endpoint}`, data).pipe(
      catchError((error) => {
        console.error('Error:', error);
        return throwError(() => error);
      })
    );
  }

  delete<T>(endpoint: string): Observable<T> {
    return this.http.delete<T>(`${this.baseUrl}/${endpoint}`).pipe(
      catchError((error) => {
        console.error('Error:', error);
        return throwError(() => error);
      })
    );
  }
}
