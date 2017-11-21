import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable'
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';

@Injectable()
export class DataService {

  baseUrl: string = "api/";

  constructor(private http: HttpClient, private authService: AuthService) { }

  get<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.authService.token })
    };

    return this.http.get<T>(currentUrl, httpOptions)
      .map((res: any) => res);
  }

  delete<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.authService.token })
    };

    return this.http.delete<T>(currentUrl, httpOptions)
      .map((res: any) => res);
  }

  post<T>(url: string, data: any = {}, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.authService.token })
    };

    return this.http.post<T>(currentUrl, data, httpOptions)
      .map((res: any) => res);
  }
}
