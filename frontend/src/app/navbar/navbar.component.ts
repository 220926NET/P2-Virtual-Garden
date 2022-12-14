import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../core/auth.service';
import { GardenService } from '../core/garden.service';
import { Router, Route, ActivatedRoute } from '@angular/router'
//import { MatFormFieldControl} from '@angular/material/form-field'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  //encapsulation: ViewEncapsulation.None
})
export class NavbarComponent implements OnInit {
  username:string="";
  loginForm: FormGroup;
  userId: string = '';

  constructor(private fb: FormBuilder,
      public authService: AuthService,
      private gService: GardenService,
      private router: Router) { 
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.username= sessionStorage.getItem("username")!;
  }

  login() {
    const val = this.loginForm.value;

    if (val.username && val.password) {
      this.authService.login(val.username, val.password)
        .subscribe(() => {
          this.loginForm.reset();
          this.getUserId().subscribe(res => {
            this.userId = res;
            sessionStorage.setItem("userId", this.userId);
            this.authService.LoggedIn = this.authService.isLoggedIn();
            sessionStorage.setItem("username", val.username);
            this.router.navigateByUrl(`user/${val.username}`);
            this.username= val.username;
          });
        });

    }

  }

  logout() {
    this.authService.logout();
    this.userId = "";
    this.router.navigateByUrl('home');
  }

  getUserId() {
    return this.authService.getUserId();
  }
  
  register() {
    const val = this.loginForm.value;

    if (val.username && val.password) {
      this.authService.register(val.username, val.password).subscribe((res) => {
        this.gService.garden.user_id = res.id;
        this.gService.addGarden(this.gService.garden).subscribe();
        this.loginForm.reset();
      });
    }
  }

}
