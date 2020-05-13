import { AuthService } from './../_services/auth.service';

import { OrderService } from './../_services/order.service';
import { Component, OnInit, Input } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

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
    public authService: AuthService
  ) { }

  ngOnInit(): void {
   this.getAllItems();
   this.sumAllItems();
  }

  addOrder(){
    this.order =
     {
       User: this.authService.currentUser,
       Items: this.orderService.cupsList,
       Date: this.date
      };
      console.log(this.order);
    this.orderService.postOrder(this.order);
    this.orderService.cupsList = [];
    localStorage.removeItem('ordersItems');
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
   this.itemsList = JSON.parse((localStorage.getItem('ordersItems')));
   this.itemsList 
   console.log(this.itemsList);
  }
}
