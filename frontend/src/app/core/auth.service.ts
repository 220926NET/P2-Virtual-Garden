import { CoreModule } from './core.module';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, shareReplay, tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { IAuthResult, IUser } from '../shared/interface';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: CoreModule,
})
export class AuthService {

  constructor(private http: HttpClient) { }

  indevelopmet:string = 'https://localhost:7077/api/login';
  api: string = environment.baseApi;

  public LoggedIn: boolean = this.isLoggedIn();

  login(username: string, password: string) {
    return this.http.post<IAuthResult>( this.api +  '/login', {username, password}).pipe(
      catchError((error: HttpErrorResponse) => {
        let message: string = "Some Error"
        if (error.error instanceof ErrorEvent) {
          message = `Error: ${error.error.message}`
        } else {
          message = `Error Code: ${error.status} Message: Login Failed`
        }
        window.alert(message);
        return throwError(() => new Error(message));
      }),
      tap((res: IAuthResult) => this.setSession(res)),
      shareReplay()
      )
  }

  register(username: string, password: string) {
    return this.http.post<IUser>( this.api + '/register', {username, password}).pipe(
      shareReplay()
    )
  }

  private setSession(result: IAuthResult) {
    sessionStorage.setItem('token', result.token);
    sessionStorage.setItem('expires', result.expires.toString());
    //this.LoggedIn = this.isLoggedIn();
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration())
  }

  logout() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('expires');
    sessionStorage.clear();
    this.LoggedIn = this.isLoggedIn();
  }

  getExpiration() {
    const expiration = sessionStorage.getItem("expires");
    return moment(expiration);
  }

  getUserId() {
    return this.http.get( this.api + '/user', { responseType: 'text' });
  }

}
