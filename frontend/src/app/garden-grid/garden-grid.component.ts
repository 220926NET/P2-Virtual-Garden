import { Component, OnInit } from '@angular/core';
import { UrlHandlingStrategy } from '@angular/router';


@Component({
  selector: 'app-garden-grid',
  templateUrl: './garden-grid.component.html',
  styleUrls: ['./garden-grid.component.css']
})
export class GardenGridComponent implements OnInit {


  constructor() { }

  ngOnInit(): void {
   
  }

  GetTileId(e:Event): void{
    let elementId: string = (e.target as Element).id;
    console.log(elementId);
  }



}
