import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  model: any = {};

  constructor(
    public authService: AuthService,
    public router: Router,
    public toastr: ToastrService
  ) {}

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe( res => {
       this.router.navigate(['/']);
       this.toastr.success('Successful Login', 'Notification');
    }
    );   
  }

  isAdmin(){
    if(this.authService.isAuthenticated()){
      this.router.navigate(['admin']);
    } else{
      this.router.navigate(['/']);
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  cancel() {
    this.router.navigate(['/']);
  }

}
