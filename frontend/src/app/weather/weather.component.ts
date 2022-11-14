import { Component, OnInit } from '@angular/core';
import { IForecast, ICoordinates } from '../shared/interface';
import { WeatherService } from '../core/weather.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  mainWeatherDesc: string = "";
  countryCode = '';
  zipCode = '';
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

  localCoodinates:ICoordinates = {
    zip: 0,
    name: "",
    lat: 0,
    lon: 0,
    country: ""
  }

  //This describes the structure the weather form data should be in
  weatherLocationForm = new FormGroup({
    zipCode: new FormControl(''),
    countryCode: new FormControl('')
  });

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.weatherService.getForecast().subscribe((forecast: IForecast) => {
      this.todaysForecast = forecast;
      this.mainWeatherDesc = forecast.weather[0].main;
    });
    
  }

  onSubmit(): void {
    let desiredCountryCode: any ;
    let desiredZipCode: any;
    
    desiredCountryCode= this.weatherLocationForm.value.countryCode;
    desiredZipCode = this.weatherLocationForm.value.zipCode;

    this.weatherService.getCoordinates(desiredCountryCode, desiredZipCode).subscribe((coords: ICoordinates) => {
      this.localCoodinates = coords;
      //put error handeling here if the getcoords function didn't return anything

      //if it did return usable coordinates, do this
      this.weatherService.getRegionalForecast(this.localCoodinates.lat, this.localCoodinates.lon).subscribe((forecast: IForecast) => {
        this.todaysForecast = forecast;
        this.mainWeatherDesc = forecast.weather[0].main;
      });
    })
  }

}



//All possible codes for main
//Thunderstorm
//Drizzle
//Rain
//Snow
//Mist
//Smoke
//Haze
//Dust
//Fog
//Sand
//Ash
//Squall
//Tornado
//Clear
//Clouds