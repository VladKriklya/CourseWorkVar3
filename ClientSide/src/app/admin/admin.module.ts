import { RouterModule } from '@angular/router';
import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';

import { AdminLayoutComponent } from './shared/admin-layout/admin-layout.component';
import { AddPageComponent } from './add-page/add-page.component';
import { EditPageComponent } from './edit-page/edit-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { QuillModule } from 'ngx-quill';
import { EditItemPageComponent } from './edit-item-page/edit-item-page.component';
import { BlockGuard } from '../_services/block.guard';





@NgModule({
  imports:[
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    QuillModule,
    RouterModule.forChild([
      { path: '', component: AdminLayoutComponent, children:[
        { path: '', redirectTo: '/admin/edit', pathMatch: 'full' },
        { path: 'add', component: AddPageComponent, canActivate: [BlockGuard]},
        { path: 'product/:id/edit', component: EditPageComponent, canActivate: [BlockGuard] },
        { path:'edit', component: EditPageComponent, canActivate: [BlockGuard]},
        { path: 'edititem', component: EditItemPageComponent, canActivate: [BlockGuard] },
        { path: '**', redirectTo: '/' }
      ]}
    ])
  ],
  exports:[
    RouterModule
  ],
  declarations: [
    AdminLayoutComponent,
    AddPageComponent,
    EditPageComponent,
    EditItemPageComponent,
  ]
})
export class AdminModule{}