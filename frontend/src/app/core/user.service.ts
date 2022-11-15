import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { IUser } from '../shared/interface';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  api: string = environment.baseApi + "users";
  constructor(private http: HttpClient) { }

  getExists(username:string):Observable<string>
  {
    return this.http.get<string>(environment.baseApi + "users/"+ username);
  }


}
