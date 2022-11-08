import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError} from 'rxjs';

import { map, catchError } from 'rxjs/operators';
import { IPost } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})

export class PostService {

  baseUrl: string = 'https://api/';

  constructor(private http: HttpClient) { }

  getAllPostsUserIsRecipientOf(): Observable<IPost[]>{
   
    return this.http.get<IPost[]>(this.baseUrl + 'post.json')
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error:any){
    console.error('server error:', error);
    if(error.error instanceof Error){
      const errMessage = error.error.message;
      return throwError(() => new Error(errMessage));

    }
    return throwError(() => new Error(error || 'Node.js server error'));
  }
  
}
