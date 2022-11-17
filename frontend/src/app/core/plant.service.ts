import { Injectable } from '@angular/core';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class PlantService {

  constructor() { }

  getPhase(timePlanted: string, timeToGrow: number): number {
    if (timeToGrow == 0) {
      return 2;
    }
    // The current time
    let currentTime: number = new Date().getTime();
    console.log(new Date(timePlanted).getTimezoneOffset());
    // The time planted
    let plantTime: number = new Date(timePlanted).getTime() - new Date(timePlanted).getTimezoneOffset() * 60000;
    // Elapsed Time
    let elapsedTime: number = currentTime - plantTime;
    // How many milliseconds per phase
    let phase: number = (timeToGrow * 60000) / 2;
    console.log(elapsedTime);
    //console.log(elapsedTime / 60000);
    if (elapsedTime < phase) {
      return 0;
    } else if (elapsedTime > phase && elapsedTime < phase * 2) {
      return 1;
    }
    return 2;
  }
}
