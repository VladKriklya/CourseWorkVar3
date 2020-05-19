import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { QuillModule } from 'ngx-quill';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrderPageComponent } from './order-page/order-page.component';



@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    RegisterPageComponent,
    NavComponent,
    LoginPageComponent,
    OrderPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    QuillModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: (() => localStorage.getItem('token')),
        whitelistedDomains: ['localhost:44303'],
        blacklistedRoutes: ['localhost:44303/api/auth']
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
