import { ItemService } from './../_services/item.service';
import { AuthService } from './../_services/auth.service';
import { ToastrService } from 'ngx-toastr';

import { OrderService } from './../_services/order.service';
import { Component, OnInit, Input } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Item } from '../_models/item';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.scss']
})
export class OrderPageComponent implements OnInit {
  allSum = 0;
  itemsList = [];
  isActive = true;
  order: any;
  date = new Date();


  constructor(
    public orderService: OrderService,
    public authService: AuthService,
    public itemService: ItemService,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
   this.getAllItems();
   this.sumAllItems();
   this.authService.currentUser = JSON.parse(localStorage.getItem('user'));
  }

  addOrder(){
    this.order =
     {
       UserId: this.authService.currentUser.id,
       User: this.authService.currentUser,
       Items: this.orderService.cupsList,
       Date: this.date.toString()
      };
      console.log(this.order);
    this.orderService.postOrder(this.order);
    this.changeItem();
    this.arrayItem();
    this.orderService.cupsList = [];
    localStorage.removeItem('ordersItems');
  }

  changeItem(){
    this.itemsList.forEach((el) => {
      el.sales++;
      el.availableItems--;
    })
  }

  arrayItem(){
   this.itemsList.forEach((el) => {
     let item = { id: el.id, name: el.name, price: el.price, imageURL: el.imageURL, sales: el.sales, 
      category: el.category, availableItems: el.availableItems};
     this.itemService.editItem(el.id, item).subscribe(() =>
        this.toastr.success('Successful  item', 'Notification'));
   })
  }

  sumAllItems(){
    this.allSum = 0;
    this.itemsList.forEach(el => {
      this.allSum += el.price;
    })
  }

  deleteItems(){
    localStorage.removeItem('ordersItems');
    this.getAllItems();
    this.sumAllItems();
  }

  getAllItems(){
   this.itemsList = <Item[]>JSON.parse((localStorage.getItem('ordersItems')));
   console.log(this.itemsList);
  }
}
