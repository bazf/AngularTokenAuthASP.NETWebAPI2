import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable'
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http'

export class User {
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


  login(userName: string, password: string): void {

    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
    };

    let body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('username', userName);
    body.set('password', password);

    this.http.post("token", body.toString(), httpOptions).subscribe(r => {
      let currentUser = new User();
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
    });
  }

  register(userName: string, password: string, confirmPassword: string): void {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    var body = {
      "userName": userName,
      "password": password,
      "confirmPassword": confirmPassword
    };

    this.http.post("api/account/register", body, httpOptions).subscribe(res => {
      var dd = res;
    });
  }

  logout(): void {
    // clear token remove user from local storage to log user out
    this.token = null;
    localStorage.removeItem('currentUser');
  }
}
