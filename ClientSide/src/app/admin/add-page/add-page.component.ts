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
  registerForm: FormGroup;

  constructor(
    private itemService: ItemService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
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
     if (this.registerForm.valid) {
      this.item = Object.assign({}, this.registerForm.value);//используется для копирования значений всех собственных перечисляемых свойств из одного или более исходных объектов в целевой объект.
      this.itemService.addItem(this.item).subscribe(
        () => {
        this.registerForm.reset();
        }
      )
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }
}
