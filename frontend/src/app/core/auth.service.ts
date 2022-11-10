import { CoreModule } from './core.module';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { shareReplay, tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { IAuthResult } from '../shared/interface';


@Injectable({
  providedIn: CoreModule,
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    return this.http.post<IAuthResult>('https://localhost:7077/api/login', {username, password}).pipe(
      tap((res: IAuthResult) => this.setSession(res)),
      shareReplay()
      )
  }

  private setSession(result: IAuthResult) {


    sessionStorage.setItem('token', result.token);
    sessionStorage.setItem('expires', result.expires.toString());
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration())
  }

  getExpiration() {
    const expiration = sessionStorage.getItem("expires");
    return moment(expiration);
  }

}
