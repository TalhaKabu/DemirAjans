import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  var token = localStorage.getItem('token');

  try {
    let decodedToken: any = jwtDecode(token!);
    const isExpired =
      decodedToken && decodedToken.exp
        ? decodedToken.exp < Date.now() / 1000
        : false;
    if (isExpired) {
      localStorage.removeItem('token');

      router.navigate(['login']);
      return false;
    }
    return true;
  } catch (error) {
    router.navigate(['login']);
    return false;
  }
};
