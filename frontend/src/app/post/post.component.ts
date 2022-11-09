import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.postService.getAllPostsUserIsRecipientOf().subscribe((posts: IPost[] )=> {
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

