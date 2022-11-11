import { Component, OnInit, SimpleChanges } from '@angular/core';
import { NgModel } from '@angular/forms';
import { MatRadioGroup } from '@angular/material/radio';
import { MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.css']
})
export class ToolsComponent implements OnInit {
  gardenRadio : string ="";
  
  //This will be filled in by the radio button selection
  //it should hold a string that is the path to the image corresponding to the selection
  

  constructor() {
    
   }

  ngOnInit(): void {
    
  }

  

  GardenButton(){
    this.gardenRadio = "";
  }
  RadioGardenButton(){
    sessionStorage.setItem('selectedTool', this.gardenRadio);
  }

  HarvestButton(){
    sessionStorage.setItem('selectedTool', 'dirt');
  }

  TendButton(){
    sessionStorage.setItem('selectedTool', 'tend');
  }

}
