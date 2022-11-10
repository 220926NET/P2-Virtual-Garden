import { CoreModule } from './core.module';
import { HttpClient } from '@angular/common/http';
import { shareReplay } from 'rxjs/operators';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: CoreModule,
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    return this.http.post<string>('https://localhost:7077/user/login', {username, password}).pipe(
      shareReplay()
      )
  }
}
