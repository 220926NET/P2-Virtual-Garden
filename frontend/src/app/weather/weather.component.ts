import { Component, OnInit } from '@angular/core';
import { IForecast } from '../shared/interface';
import { WeatherService } from '../core/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  mainWeatherDesc: string = "";
  todaysForecast:  IForecast ={
    coord: {
      lon: 0,
      lat: 0
  },
  weather: [
      {
          id: 0,
          //This or description are mainly what we are after
          main: "",
          description: "",
          icon: ""
      }
  ],
  base: "",
  main: {
      temp: 0,
      feels_like: 0,
      temp_min: 0,
      temp_max: 0,
      pressure: 0,
      humidity: 0
  },
  visibility: 0,
  wind: {
      speed: 0,
      deg: 0
  },
  clouds: {
      all: 0
  },
  dt: 0,
  sys: {
      type: 0,
      id: 0,
      country: "",
      sunrise: 0,
      sunset: 0
  },
  timezone: 0,
  id: 0,
  name: "",
  cod: 0
  
  } ;

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.weatherService.getForecast().subscribe((forecast: IForecast) => {
      this.todaysForecast = forecast;
      console.log(forecast);
      this.mainWeatherDesc = forecast.weather[0].main;
    });
    
  }

}
