import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable'
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Router } from '@angular/router';
import 'rxjs/add/operator/toPromise';

import { CurrentUser } from '../custom-types/current-user';
import { AuthData } from '../custom-types/auth-data';

@Injectable()
export class AuthService {
  constructor(private http: HttpClient, private router: Router) {
    this.fillAuthDataFromStorage();
  }

  private authData: AuthData = new AuthData();

  private fillAuthData(data: Object) {
    let currentUser = new CurrentUser();
    Object.assign(currentUser, data);

    if (currentUser == null) return;

    localStorage.setItem("currentUser", JSON.stringify({
      userName: currentUser.userName,
      token: currentUser.access_token,
      expires_in: currentUser.expires_in,
      roles: currentUser.roles,
      id: currentUser.id,
      issued: currentUser.issued,
      expires: currentUser.expires
    }));

    this.authData.id = currentUser.id;
    this.authData.userName = currentUser.userName;
    this.authData.roles = currentUser.roles;
    this.authData.isAuth = currentUser.access_token && true;
  }

  private fillAuthDataFromStorage() {
    var storageUser = JSON.parse(localStorage.getItem('currentUser'));
    if (storageUser == null) return;

    let user = new CurrentUser();
    Object.assign(user, storageUser);

    this.authData.id = user.id;
    this.authData.userName = user.userName;
    this.authData.roles = user.roles;
    this.authData.isAuth = true;
  }

  redirectUrl: string = "/home/my-notes";

  isInRole(role: string): boolean {
    if (this.authData.roles != undefined) {
      return this.authData.roles.includes(role);
    } else {
      return false;
    }
  }

  getAuthData(): AuthData {
    return this.authData;
  }

  login(userName: string, password: string): Promise<string> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
    };

    let authData = new URLSearchParams();
    authData.set('grant_type', 'password');
    authData.set('username', userName);
    authData.set('password', password);

    let promise = new Promise<string>((resolve, reject) => {
      this.http.post("token", authData.toString(), httpOptions)
        .toPromise()
        .then(r => { this.fillAuthData(r); resolve("success"); },
        e => { reject(e.error.error_description); });
    });
    return promise;
  }

  register(userName: string, password: string, confirmPassword: string): Promise<string> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    var registrationData = {
      "userName": userName,
      "password": password,
      "confirmPassword": confirmPassword
    };

    let promise = new Promise<string>((resolve, reject) => {
      this.http.post("api/account/register", registrationData, httpOptions)
        .toPromise()
        .then(r => { resolve("success"); },
        e => { reject(e.error.error_description); });
    });

    return promise;
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.authData = new AuthData();
    this.router.navigate(['login']);
  }
}
