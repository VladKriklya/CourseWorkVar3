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
import { Item } from 'src/app/_models/item';

@Component({
  selector: 'app-add-page',
  templateUrl: './add-page.component.html',
  styleUrls: ['./add-page.component.scss']
})
export class AddPageComponent implements OnInit {
  item: Item;
  addForm: FormGroup;

  constructor(
    private itemService: ItemService,
    private router: Router,
    private fb: FormBuilder,
    public toastr: ToastrService
  ) {}

  ngOnInit() {
    this.createAddForm();
  }

  createAddForm() {
    this.addForm = this.fb.group(
      {
        name: ['', Validators.required],
        price: [null,  Validators.required],
        imageurl: ['', Validators.required],
        sales: [null, Validators.required],
        category: [null, Validators.required],
        availableitems: [null, Validators.required]
      }
    )
  }

  addItem() {
     if (this.addForm.valid) {
      this.item = Object.assign({}, this.addForm.value);//используется для копирования значений всех собственных перечисляемых свойств из одного или более исходных объектов в целевой объект.
      this.itemService.addItem(this.item).subscribe(res => {
        this.toastr.success('Successful Add', 'Notification');
      }
      )
      this.addForm.reset();
    }
  }
  


  cancel() {
    this.router.navigate(['/']);
  }
}
