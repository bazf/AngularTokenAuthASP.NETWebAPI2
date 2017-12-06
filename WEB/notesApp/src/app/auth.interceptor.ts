import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var storageUser = JSON.parse(localStorage.getItem('currentUser'));
    let access_token = storageUser && storageUser.token;
    const authHeader = 'Bearer ' + access_token;

    const authReq = req.clone({ headers: req.headers.set('Authorization', authHeader) });

    return next.handle(authReq).do(event => { }, err => {
      if (err instanceof HttpErrorResponse) {
        // redirect to login page, in future should be different views for every error
        switch (err.status) {
          case 401: this.router.navigate(['login']); break;
          case 403: this.router.navigate(['login']); break;
          case 500: this.router.navigate(['login']); break;
        }
      }
    });
  }
}
