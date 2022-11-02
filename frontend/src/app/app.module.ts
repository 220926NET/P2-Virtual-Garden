import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ToolsComponent } from './tools/tools.component';
import { GardenComponent } from './garden/garden.component';
import { PostComponent } from './post/post.component';
import { GardenGridComponent } from './garden-grid/garden-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ToolsComponent,
    GardenComponent,
    PostComponent,
    GardenGridComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
