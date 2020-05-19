import { OrderPageComponent } from './order-page/order-page.component';
import { NavComponent } from './nav/nav.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { LoginPageComponent } from './login-page/login-page.component';


const routes: Routes = [
  { path: '', component: NavComponent, children:[
    { path: '', redirectTo: '/', pathMatch: 'full' },
    { path: '', component: MainPageComponent },
    { path: 'registration', component: RegisterPageComponent },
    { path: 'login', component: LoginPageComponent },
    { path: 'order', component: OrderPageComponent },
  ]},
  { path: 'admin', loadChildren: () => import('src/app/admin/admin.module').then(m => m.AdminModule) },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
