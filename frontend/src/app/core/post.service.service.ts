import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { IPost } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})
export class PostServiceService {

  baseURL:string = "https://localhost:7077/api/"

  constructor(private http: HttpClient) { }

  getPost():Observable<any[]>{
    return this.http.get(this.baseURL + "get") as Observable<any[]>;

  }
  sendPost(post:IPost) : Observable<Object>{
    return this.http.post(this.baseURL + "post/",post);
  }
}
