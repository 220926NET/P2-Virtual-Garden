import { Component, OnInit } from '@angular/core';
import { WeatherComponent } from '../weather/weather.component';


@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})

export class GardenComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
