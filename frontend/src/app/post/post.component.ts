import { emitDistinctChangesOnlyDefaultValue, ParseError } from '@angular/compiler';
import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Params } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Output, EventEmitter } from '@angular/core'
import { timer } from 'rxjs';

import {PostService} from '../core/post.service';
import { IPost } from '../shared/interface';
import { GardenService } from '../core/garden.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit{

  comments: IPost[] = [];
  bunchaPosts : IPost[] = []
  //do not gaa or gcm before removing this
  userId : Guid = Guid.parse('9eb40a35-7a1f-44b5-af6f-68440861cbf4');
  comment = new FormControl();


  constructor(private postService: PostService, private gardenService:GardenService) { }

  doRender(): void {
    this.postService.getAllPostsUserIsRecipientOf(Guid.parse(this.gardenService.garden.user_id)).subscribe((posts: IPost[] )=> {
      this.bunchaPosts = posts;
      console.log(this.bunchaPosts);
      this.comments = this.bunchaPosts;
    });
  }

  ngOnInit(): void {
    timer(2000, 60000).subscribe({
      next: () => { this.doRender(); },
      error: (err) => { console.error(err); }
    })
    
  }



  openForm() {
    
    document.getElementById("myForm")!.style.display = "block";

  }
  
  closeForm() {
    document.getElementById("myForm")!.style.display = "none";
  }

  submitMessage(){
    let now = new Date();
    let post:IPost={
      id: Guid.EMPTY,
      //person logged in at the moment
      sender_id:sessionStorage.getItem("userId")!,
      //the garden owner's id, from the URL?
      reciver_id:this.gardenService.garden.user_id,
      text:this.comment.value,
      time: now,
      sender_name: sessionStorage.getItem("username")!
    }
    this.postService.sendPost(post).subscribe((res) =>{
      console.log(res)
    });
    this.comments.splice(0,0,post);

  }

}

