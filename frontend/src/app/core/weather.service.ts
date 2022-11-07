import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { map, catchError } from 'rxjs';
import { IForecast } from '../shared/interface';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  baseUrl: string = '';
  constructor() { }
}
