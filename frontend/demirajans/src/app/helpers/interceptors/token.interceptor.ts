import { HttpInterceptorFn } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  let router = Inject(Router);
  const token = localStorage.getItem('token');

  if (token) {
    try {
      let decodedToken = jwtDecode(token);
      const isExpired =
        decodedToken && decodedToken.exp
          ? decodedToken.exp < Date.now() / 1000
          : false;

      if (isExpired) {
        localStorage.removeItem('token');
        router.navigate['/login'];
      } else return next(req);
    } catch (error) {
      localStorage.removeItem('token');
      router.navigate['/login'];
    }
  } else {
    if (req.url.includes('Auth/login')) {
      return next(req);
    } else {
      localStorage.removeItem('token');
      router.navigate['/login'];
    }
  }

  return next(req);
};
