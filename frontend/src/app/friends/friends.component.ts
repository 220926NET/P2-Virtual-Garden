import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FriendService } from '../core/friend.service';
import { IFriendRelationship } from '../shared/interface';
import { map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  display:IFriendRelationship[]=[];

  constructor(private _friendService:FriendService, private router: Router) { 
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };
  }

  friend : string = '';

  friendForm = new FormGroup({
    friend: new FormControl("")
  });

  ngOnInit(): void {
    this._friendService.getFriend(sessionStorage.getItem("username")!).subscribe(
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
    this._friendService.getFriend(sessionStorage.getItem("username")!).subscribe(
      {
        next:(res) =>{
          this.display = res;
        },
        error:(err) =>{
          console.log("friends not sent")
        }
        
      }
    )

      //this.display = [{username:"user", friendname: "something"}]
  
  }

  GoToPage() {
    this.router.navigateByUrl(`user/${this.friend}`);
  }

}
