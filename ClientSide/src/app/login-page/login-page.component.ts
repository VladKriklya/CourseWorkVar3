import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  model: any = {};

  constructor(
    public authService: AuthService,
    public router: Router
  ) {}

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      error => {
        console.log(error);
      },
      () => {
        this.router.navigate(['/']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

}
