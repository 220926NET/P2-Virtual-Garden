import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ToolsComponent } from './tools/tools.component';
import { GardenComponent } from './garden/garden.component';
import { PostComponent } from './post/post.component';
import { GardenGridComponent } from './garden-grid/garden-grid.component';
import { WeatherComponent } from './weather/weather.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { LandingPageModule } from './landing-page/landing-page.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRadioModule} from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';


import { MatToolbarModule } from '@angular/material/toolbar'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button'
import { AuthInterceptorService } from './core/authInterceptor.service';

import { AppRoutingModule } from './app-routing.module';

import { FriendsComponent } from './friends/friends.component';
import { UserPageComponent } from './user-page/user-page.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ToolsComponent,
    GardenComponent,
    GardenGridComponent,
    PostComponent,
    GardenGridComponent,
    WeatherComponent,
    FriendsComponent,
    UserPageComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    CoreModule,
    ReactiveFormsModule,
    LandingPageModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatRadioModule,
    FormsModule,
    MatSelectModule,
    AppRoutingModule
  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true } ],
  bootstrap: [AppComponent]
})
export class AppModule { }
