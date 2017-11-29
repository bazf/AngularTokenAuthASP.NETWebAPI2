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
  private baseUrl: string = "api/";

  constructor(private http: HttpClient) {
  }

  get<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();
    return this.http.get<T>(currentUrl)
      .map((res: any) => res);
  }

  delete<T>(url: string, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();
    return this.http.delete<T>(currentUrl)
      .map((res: any) => res);
  }

  post<T>(url: string, data: any = {}, parameter: any = ""): Observable<T> {
    var currentUrl = this.baseUrl + url + "/" + parameter.toString();
    return this.http.post<T>(currentUrl, data)
      .map((res: any) => res);
  }
}
