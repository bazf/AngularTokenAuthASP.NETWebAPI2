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

  get<T>(url: string): Observable<T> {
    var currentUrl = this.baseUrl + url;

    let httpOptions = {
      headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.authService.token })
    };

    return this.http.get<T>(currentUrl, httpOptions)
      .map((res: any) => res);
  }

  //get(url: string): Promise<Object> {
  //  var currentUrl = "api/values";// this.baseUrl + url;
  //  let promise = new Promise<Response>((resolve, reject) => {
  //    this.http.get<Response>(currentUrl)
  //      .map((res: Response) => res.json())
  //      .toPromise()
  //      .then(r => {
  //        var j = r;
  //      resolve(j)
  //    });
  //  });
  //  return promise;
  //}
}
