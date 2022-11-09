import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IGarden } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})
export class GardenService {
  api: string = environment.baseApi + 'garden';
  constructor(private http: HttpClient) { }

  addGarden(garden: IGarden): Observable<IGarden> {
    return this.http.post<IGarden>(this.api, garden);
  }

  deleteGarden(garden: IGarden): Observable<IGarden> {
    return this.http.delete<IGarden>(this.api, { body: garden });
  }

  updateGarden(garden: IGarden): Observable<IGarden> {
    return this.http.put<IGarden>(this.api, garden);
  }

  getGarden(userId: string): Observable<IGarden> {
    return this.http.get<IGarden>(this.api + '/' + userId);
  }
}
