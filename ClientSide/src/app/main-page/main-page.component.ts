import { Component, OnInit } from '@angular/core';
import { ItemService } from '../_services/item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  itemList = [];
  itemTempList = [];
  tempArray = [];

  constructor(
    public itemService: ItemService,
    public router: Router
  ) { }

  ngOnInit(): void {
    this.itemService.getItems()
      .subscribe(res => this.itemList = this.itemTempList = res as []);
  }

  getCups(index : number){
    this.itemList = this.itemTempList;
    this.tempArray = [];
    this.itemList.forEach((el) => {
      if(el.category == index){
        this.tempArray.push(el);
      }
    })
    this.itemList = this.tempArray;
  }

  getAllCups(){
    this.itemList = this.itemTempList;
  }

  cancel(){
    this.router.navigate(['/']);

  }
}
