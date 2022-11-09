import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Params } from '@angular/router';

import { PostService } from '../core/post.service';
import { IPost } from '../shared/interface';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit{

  comments: string[] = [];
  bunchaPosts : IPost[] = []
  //do not gaa or gcm before removing this
  userId : Params = {userId: "9eb40a35-7a1f-44b5-af6f-68440861cbf4"};

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.postService.getAllPostsUserIsRecipientOf(this.userId).subscribe((posts: IPost[] )=> {
      this.bunchaPosts = posts;
      console.log(this.bunchaPosts);
    });
    
  }


  openForm() {
    
    document.getElementById("myForm")!.style.display = "block";

  }
  
  closeForm() {
    document.getElementById("myForm")!.style.display = "none";
  }

  submitMessage(){

  }

}

