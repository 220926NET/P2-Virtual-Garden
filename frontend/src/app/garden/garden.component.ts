import { Component, OnInit } from '@angular/core';
import { FriendService } from '../core/friend.service';
import { IFriendRelationship } from '../shared/interface';
import { WeatherComponent } from '../weather/weather.component';


@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})

export class GardenComponent implements OnInit {

  constructor(private fservice: FriendService) { }

  ngOnInit(): void {
    const rel: IFriendRelationship = {
      username: "duncan",
      friendname: "Rushay"
    }
    this.fservice.deleteFriend(rel).subscribe((res) => {
      console.log(res);
    })
  }

}
