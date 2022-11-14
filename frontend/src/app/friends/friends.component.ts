import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FriendService } from '../core/friend.service';
import { IFriendRelationship } from '../shared/interface';
import { map, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  display:IFriendRelationship[]=[];

  constructor(private _friendService:FriendService) { }

  ngOnInit(): void {
    this._friendService.getFriend("jallen").subscribe(
      {
        next:(res) =>{
          this.display = res;
        },
        error:(err) =>{
          console.log("friends not sent")
        }
        
      }
    )
  }

  getFriends(){
    this._friendService.getFriend("jallen")
      .pipe(
        map((value:IFriendRelationship[]) => {
        this.display = value;
        })
      )

      //this.display = [{username:"user", friendname: "something"}]
  
  }

}
