import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class TokenHelperService {
  private token = localStorage.getItem('token');

  constructor() {}

  getUserIdFromToken(): number {
    let decodedToken: any = jwtDecode(this.token!);

    const nameIdentifier =
      decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ];
    return nameIdentifier;
  }
}
