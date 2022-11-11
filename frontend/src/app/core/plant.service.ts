import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PlantService {

  constructor() { }

  getPhase(timePlanted: string, timeToGrow: number): number {
    // The current time
    let currentTime: number = Date.now();
    // The time planted
    let plantTime: number = new Date(timePlanted).getTime();
    // Elapsed Time
    let elapsedTime: number = currentTime - plantTime;
    // How many milliseconds per phase
    let phase: number = (timeToGrow * 60000) / 2;
    //console.log(elapsedTime / 60000);
    if (elapsedTime < phase) {
      return 0;
    } else if (elapsedTime > phase && elapsedTime < phase * 2) {
      return 1;
    }
    return 2;
  }
}
