import { CoreModule } from './core.module';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { shareReplay, tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: CoreModule,
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    return this.http.post('https://localhost:7077/api/login', {username, password}, { responseType: 'text' }).pipe(
      tap(res => this.setSession(res)),
      shareReplay()
      )
  }

  private setSession(result: string) {
    sessionStorage.setItem('token', result)
  }
}
