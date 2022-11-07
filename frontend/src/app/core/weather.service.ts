import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { map, catchError } from 'rxjs';
import { IForecast } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  baseUrl: string = 'https://api.openweathermap.org/data/2.5/weather?';
  constructor(private http: HttpClient) { }

  getForecast() : Observable<IForecast>{
    
    var myForecast = this.http.get<IForecast>(this.baseUrl + 'lat=35.95&lon=-86.66&appid=f78b83839e67bea5a6c860811cef3a6d&units=imperial');
    console.log(myForecast);
    return myForecast;
  }
}
