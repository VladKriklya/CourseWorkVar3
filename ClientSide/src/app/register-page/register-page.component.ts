import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { User } from '../_models/user';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {
  user: User;
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        username: ['', Validators.required],
        email: ['', [ Validators.required, Validators.email]],
        role: [2, Validators.required],
        address: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8)
          ]
        ]
      }
    )
  }

  register() {
     if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);//используется для копирования значений всех собственных перечисляемых свойств из одного или более исходных объектов в целевой объект.
      this.authService.register(this.user).subscribe(
        () => {
          this.authService.login(this.user).subscribe(() => {
            this.router.navigate(['/']);
          });
        }
      );
      }
  }

  cancel() {
    this.router.navigate(['/']);
  }
}
