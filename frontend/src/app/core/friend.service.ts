import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IFriendRelationship } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})
export class FriendService {
  api: string = environment.baseApi + "friend";
  constructor(private http: HttpClient) { }

  addFriend(rel: IFriendRelationship): Observable<IFriendRelationship> {
    return this.http.post<IFriendRelationship>(this.api, rel);
  }

  getFriend(username: string): Observable<IFriendRelationship[]> {
    return this.http.request<IFriendRelationship[]>('GET', this.api, { body: username });
  }

  deleteFriend(rel: IFriendRelationship): Observable<IFriendRelationship> {
    return this.http.delete<IFriendRelationship>(this.api, { body: rel });
  }
}
