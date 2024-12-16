import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class TokenHelperService {
  private token = localStorage.getItem('token');

  constructor(private router: Router) {}

  getToken(): number {
    try {
      let decodedToken: any = jwtDecode(this.token!);
      const isExpired =
        decodedToken && decodedToken.exp
          ? decodedToken.exp < Date.now() / 1000
          : false;
      console.log(isExpired);
      if (isExpired) {
        localStorage.removeItem('token');
        this.router.navigate(['/login']);
        return 0;
      }
      const nameIdentifier =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ];
      return nameIdentifier;
    } catch (error) {
      this.router.navigate(['/login']);
      return 0;
    }
  }
}
