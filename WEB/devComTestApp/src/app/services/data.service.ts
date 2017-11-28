import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable'
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { CurrentUser } from '../custom-types/current-user';

@Injectable()
export class DataService {

  private access_token: string;
  private baseUrl: string = "api/";

  constructor(private http: HttpClient) {
    var storageUser = JSON.parse(localStorage.getItem('currentUser'));
    //let user = new CurrentUser();
    //Object.assign(user, storageUser);
    this.access_token = storageUser && storageUser.token;

  }

  get<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.access_token })
    };

    return this.http.get<T>(currentUrl, httpOptions)
      .map((res: any) => res);
  }

  delete<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.access_token })
    };

    return this.http.delete<T>(currentUrl, httpOptions)
      .map((res: any) => res);
  }

  post<T>(url: string, data: any = {}, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.access_token })
    };

    return this.http.post<T>(currentUrl, data, httpOptions)
      .map((res: any) => res);
  }
}
