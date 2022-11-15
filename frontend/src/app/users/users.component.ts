import { Component, OnInit } from '@angular/core';
import { IUser, IFriendRelationship } from '../shared/interface';
import { UserService } from '../core/user.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FriendService } from '../core/friend.service';



@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  display:string = "";
  friendForm = new FormGroup({
    friendName:new FormControl('')
  })
  friend:IFriendRelationship = {
    username: "",
    friendname: ""
}
 
  constructor(private _userService:UserService, private _friendService:FriendService) { }

  ngOnInit(): void {
  }

  getExists(){
    let myfriend:any;
    myfriend = this.friendForm.value.friendName;
    this._userService.getExists(myfriend).subscribe(
      {
        next:(res) =>{
          this.display = res
        },
        error:(err) =>{
          console.log("Users not sent");
        }
        
      }
    )
    if (this.display==null){
      this.friend.friendname = myfriend;
      this.friend.username = sessionStorage.getItem("username")!;
      this._friendService.addFriend(this.friend).subscribe(
        {
          next:(res) => {
            console.log(res);
          },
          error:(err) => console.error(err)
        }
      );
    }
  }

}
