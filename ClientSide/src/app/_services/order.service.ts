import { AuthService } from './auth.service';
import { Item } from './../_models/item';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderService implements OnInit {

  cupsList = [];
  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
  }

  postOrder(order){
    this.http.post("https://localhost:44303/api/order", order);
  }

  addItem(item){
    this.cupsList.push(item);
    localStorage.setItem('ordersItems', JSON.stringify(this.cupsList))
  }
}
