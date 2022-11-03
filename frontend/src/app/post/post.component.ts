import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit {
msg: any;
  
  constructor() { }

  ngOnInit(): void {
  }

  openForm() {
    
    document.getElementById("myForm")!.style.display = "block";

  }
  
  closeForm() {
    document.getElementById("myForm")!.style.display = "none";
  }

  submitMessage(){
    const val = (<HTMLInputElement>document.getElementById("text")).value;
    this.newTextBox = 

  }

}

