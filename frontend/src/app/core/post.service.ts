import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Params } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { Guid } from 'guid-typescript';

import { map, catchError } from 'rxjs/operators';
import { IPost } from '../shared/interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class PostService {

  swaggerBaseUrl: string = environment.baseApi;

  constructor(private http: HttpClient) { }

  getAllPostsUserIsRecipientOf(userId: Guid): Observable<IPost[]> {
    return this.http.get<IPost[]>(`${this.swaggerBaseUrl}get/${userId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  sendPost(post: IPost): Observable<Object> {
    return this.http.post(this.swaggerBaseUrl + "post/", post);
  }

  private handleError(error: any) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => new Error(errMessage));

    }
    return throwError(() => new Error(error || 'Node.js server error'));
  }

}
