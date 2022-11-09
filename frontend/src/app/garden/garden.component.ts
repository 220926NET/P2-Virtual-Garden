import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { FriendService } from '../core/friend.service';
import { GardenService } from '../core/garden.service';
import { IFriendRelationship, IGarden } from '../shared/interface';
import { WeatherComponent } from '../weather/weather.component';


@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})

export class GardenComponent implements OnInit {

  constructor(private gservice: GardenService) { }

  ngOnInit(): void {
    let garden: IGarden = {
      id: Guid.EMPTY,
      user_id: "28e70132-9ae8-4cce-8566-712aead94e94",
      tiles: []
    }
    console.log(JSON.stringify(garden));
    this.gservice.addGarden(garden).subscribe((res) => {
      this.gservice.getGarden(res.user_id).subscribe((res2) => {
        this.gservice.updateGarden(res2).subscribe((res3) => {
          this.gservice.deleteGarden(res3).subscribe((res4) => {
            console.log(res4);
          })
        })
      })
    })
  }

}
