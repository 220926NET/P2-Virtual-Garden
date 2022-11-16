import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  condition:boolean  = true;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    //get name of person whose garden is being displayed
    let name:string = this.route.snapshot.paramMap.get('username')!;
    //get name of user logged in
    let username = sessionStorage.getItem("username")!;
    this.condition = (name === username);

    
  }

}
