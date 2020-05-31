import { ToastrService } from 'ngx-toastr';
import { ItemService } from './../../_services/item.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-item-page',
  templateUrl: './edit-item-page.component.html',
  styleUrls: ['./edit-item-page.component.scss']
})
export class EditItemPageComponent implements OnInit {
  editForm: FormGroup;
  item;

  constructor(
    private itemService: ItemService,
    private router: Router,
    private fb: FormBuilder,
    public toastr: ToastrService
  ) {}

  ngOnInit() {
    this.createEditForm();
  }

  createEditForm() {
    this.editForm = this.fb.group(
      {
        id: [this.itemService.currentItem.id, Validators.required],  
        name: [this.itemService.currentItem.name, Validators.required],
        price: [this.itemService.currentItem.price,  Validators.required],
        imageurl: [this.itemService.currentItem.imageUrl, Validators.required],
        sales: [this.itemService.currentItem.sales, Validators.required],
        category: [this.itemService.currentItem.category, Validators.required],
        availableitems: [this.itemService.currentItem.availableItems, Validators.required]
      }
    )
  }

  editItem() {
     if (this.editForm.valid) {
      this.item = Object.assign({}, this.editForm.value);
      this.itemService.editItem(this.itemService.idItem, this.item)
       .subscribe(() => {
        this.toastr.success('Successful Edit', 'Notification');
        this.toastr.warning('You may need to refresh page to get updated information', 'ATTENTION');
      })
      this.itemService.idItem = null;
      this.itemService.currentItem = null;
      this.item = null;
      this.router.navigate(['/admin','edit']);
     }
  }

  cancel(){
    this.router.navigate(['/admin','edit']);
  }
}
