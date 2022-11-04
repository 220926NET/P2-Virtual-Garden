import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit{

  comments: string[] = [];

  constructor() { }

  ngOnInit(): void {}


  openForm() {
    
    document.getElementById("myForm")!.style.display = "block";

  }
  
  closeForm() {
    document.getElementById("myForm")!.style.display = "none";
  }

  submitMessage(){

  }

}

