import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WelcomeToolsComponent } from './welcome-tools/welcome-tools.component';
import { WelcomeGardenComponent } from './welcome-garden/welcome-garden.component';
import { WelcomePostsComponent } from './welcome-posts/welcome-posts.component';
import { LandingPageComponent } from './landing-page.component';



@NgModule({
  declarations: [
    WelcomeToolsComponent,
    WelcomeGardenComponent,
    WelcomePostsComponent,
    LandingPageComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    WelcomeGardenComponent,
    WelcomeToolsComponent,
    WelcomePostsComponent,
    LandingPageComponent
  ]
})
export class LandingPageModule { }
