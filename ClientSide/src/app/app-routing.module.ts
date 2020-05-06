import { NavComponent } from './nav/nav.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import { LoginPageComponent } from './login-page/login-page.component';


const routes: Routes = [
  { path: '', component: NavComponent, children:[
    { path: '', redirectTo: '/', pathMatch: 'full' },
    { path: '', component: MainPageComponent },
    { path: 'product/:id', component: ProductPageComponent },
    { path: 'cart', component: CartPageComponent },
    { path: 'registration', component: RegisterPageComponent },
    { path: 'login', component: LoginPageComponent }
  ]},
  { path: 'admin', loadChildren: () => import('src/app/admin/admin.module').then(m => m.AdminModule) },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
