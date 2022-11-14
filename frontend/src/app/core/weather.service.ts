import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { map, catchError } from 'rxjs';
import { ICoordinates, IForecast } from '../shared/interface';
import { SecretServiceService } from './secret-service.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  apiid: string = "";

  baseUrl: string = 'https://api.openweathermap.org/data/2.5/weather?';
  constructor(private http: HttpClient, private secret :SecretServiceService) { }

  getForecast() : Observable<IForecast>{
    this.apiid = this.secret.getApiKey(); 
    var myForecast = this.http.get<IForecast>(this.baseUrl + `lat=35.95&lon=-86.66&appid=${this.apiid}&units=imperial`);
    // console.log(myForecast);
    return myForecast;
  }

  getCoordinates(countryCode: string, zipCode:string) : Observable<ICoordinates> {
    return this.http.get<ICoordinates>(`http://api.openweathermap.org/geo/1.0/zip?zip=${zipCode},${countryCode}&appid=${this.apiid}`);
  }

  getRegionalForecast(regLat:number, regLon:number) : Observable<IForecast>{
    this.apiid = this.secret.getApiKey(); 
    var myForecast = this.http.get<IForecast>(this.baseUrl + `lat=${regLat}&lon=${regLon}&appid=${this.apiid}&units=imperial`);
    // console.log(myForecast);
    return myForecast;
  }

  


}
