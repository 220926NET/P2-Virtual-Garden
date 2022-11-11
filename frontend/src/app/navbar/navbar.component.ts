import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../core/auth.service';
//import { MatFormFieldControl} from '@angular/material/form-field'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  //encapsulation: ViewEncapsulation.None
})
export class NavbarComponent implements OnInit {

  loginForm: FormGroup;
  constructor(private fb: FormBuilder, public authService: AuthService) { 
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    console.log(this.authService.isLoggedIn())
  }

  login() {
    const val = this.loginForm.value;

    if (val.username && val.password) {
      this.authService.login(val.username, val.password)
        .subscribe(() => {
          this.loginForm.reset();});
    }

  }

  logout() {
    this.authService.logout();
  }

}
