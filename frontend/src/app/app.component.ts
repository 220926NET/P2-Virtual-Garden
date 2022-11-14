import { Component, NgModule, OnInit } from '@angular/core';
import { LandingPageModule } from './landing-page/landing-page.module';
import { WelcomeToolsComponent } from './landing-page/welcome-tools/welcome-tools.component';
import { WelcomeGardenComponent } from './landing-page/welcome-garden/welcome-garden.component';
import { WelcomePostsComponent } from './landing-page/welcome-posts/welcome-posts.component';


import { LandingPageComponent } from './landing-page/landing-page.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{

  title = 'frontend';
  user : string = "hello";
  noUser : string = "";

  ngOnInit(): void {
    throw new Error('Method not implemented.');
    
  }
  

}
