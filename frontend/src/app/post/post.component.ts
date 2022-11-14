import { emitDistinctChangesOnlyDefaultValue, ParseError } from '@angular/compiler';
import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Params } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Output, EventEmitter } from '@angular/core'

import {PostService} from '../core/post.service';
import { IPost } from '../shared/interface';

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


  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.postService.getAllPostsUserIsRecipientOf(this.userId).subscribe((posts: IPost[] )=> {
      this.bunchaPosts = posts;
      console.log(this.bunchaPosts);
      this.comments = this.bunchaPosts;
    });
    
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
      sender_id:"9eb40a35-7a1f-44b5-af6f-68440861cbf4",
      reciver_id:"9eb40a35-7a1f-44b5-af6f-68440861cbf4",
      text:this.comment.value,
      time: now,
      sender_name: "duncan"
    }
    this.postService.sendPost(post).subscribe((res) =>{
      console.log(res)
    });
    this.comments.splice(0,0,post);

  }

}

