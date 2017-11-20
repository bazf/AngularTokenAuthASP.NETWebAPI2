import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable'
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http'

import 'rxjs/add/operator/toPromise';

export class CurrentUser {
  access_token: string;
  token_type: string;
  expires_in: number;
  userName: string;
  roles: string[];
  id: string;
  issued: string;
  expires: string;
}

@Injectable()
export class AuthService {
  public token: string;

  constructor(private http: HttpClient) {
    // set token if saved in local storage
    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.token = currentUser && currentUser.token;
  }

  login(userName: string, password: string): Promise<string> {

    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
    };

    let body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('username', userName);
    body.set('password', password);

    let promise = new Promise <string>((resolve, reject) => {
      this.http.post("token", body.toString(), httpOptions)
        .toPromise()
        .then(
        r => {
          let currentUser = new CurrentUser();
          Object.assign(currentUser, r);

          localStorage.setItem("currentUser", JSON.stringify({
            username: currentUser.userName,
            token: currentUser.access_token,
            expires_in: currentUser.expires_in,
            roles: currentUser.roles,
            id: currentUser.id,
            issued: currentUser.issued,
            expires: currentUser.expires
          }));

          resolve("success");
        },
        e => {
          reject(e.error.error_description);
        }
        );
    });
    return promise;
  }

  register(userName: string, password: string, confirmPassword: string): Promise<string> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    var body = {
      "userName": userName,
      "password": password,
      "confirmPassword": confirmPassword
    };

    let promise = new Promise<string>((resolve, reject) => {
      this.http.post("api/account/register", body, httpOptions)
        .toPromise()
        .then(
        r => {
          resolve("success");
        },
        e => {
          reject(e.error.error_description);
        }
        );
    });

    return promise;
  }

  logout(): void {
    // clear token remove user from local storage to log user out
    this.token = null;
    localStorage.removeItem('currentUser');
  }
}
